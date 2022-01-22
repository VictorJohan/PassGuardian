using Newtonsoft.Json;
using PassGuardian.Models;
using PassGuardian.Utils;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PassGuardian.BLL
{
    public class UserBLL
    {
        public HttpClient Http { get; set; }
        public Response Response { get; set; }
        public UserBLL()
        {
            Http = Host.GetClient();
            
        }

        public async Task<bool> Save(User user)
        {
            User User = new User();
            var result = await Http.PostAsJsonAsync($"{Host.PassGuardianHost}user/save", user);

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

        public async Task<User> Login(User user)
        {
            User User = new User();
            var result = await Http.PostAsJsonAsync($"{Host.PassGuardianHost}user/login", user);
           
            if (result.IsSuccessStatusCode)
            {
                User = JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
                return User;
            }
            else
            {
                Response = JsonConvert.DeserializeObject<Response>(await result.Content.ReadAsStringAsync());

                return User;
            }
              
           
        }
    }
}
