using Newtonsoft.Json;
using PassGuardian.Models;
using PassGuardian.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PassGuardian.BLL
{
    public class PasswordBLL
    {
        private HttpClient Http { get; set; }
        public Response Response { get; set; }
        public PasswordBLL()
        {
            Http = Host.GetClient();
            
        }


        public async Task<bool> Save(Password password)
        {
            var result = await Http.PostAsJsonAsync($"{Host.PassGuardianHost}password/save", password);

            if(result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<bool> Delete(Password password)
        {
            var result = await Http.PostAsJsonAsync($"{Host.PassGuardianHost}password/delete", password);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                Response = JsonConvert.DeserializeObject<Response>(await result.Content.ReadAsStringAsync());
                return false;
            }
           
        }

        public async Task<string> GetPasswordFromServer(int user)
        {
            Password password = null;

            password = await Http.GetFromJsonAsync<Password>($"{Host.PassGuardianHost}password/generatepasswordtouser?id={user}");
            if (password != null)
                return password.ApplicationPassword;

            return "";
        }
        public async Task<List<Password>> GetPasswordsByUser(int user)
        {
            List<Password> passwords = new();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient http = new(clientHandler);
           

            passwords = await http.GetFromJsonAsync<List<Password>>($"{Host.PassGuardianHost}password/listbyuser?id={user}");
            if (passwords != null)
                return passwords;

            return new List<Password>();
        }

    }
}
