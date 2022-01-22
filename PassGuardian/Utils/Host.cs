using System.Net.Http;

namespace PassGuardian.Utils
{
    public class Host
    {
        public readonly static string PassGuardianHost = @"https://192.168.1.3:8020/api/";
        public readonly static string Key = "39725f1ed07647280ff674623855c3d0";

        public static HttpClient GetClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient http = new(clientHandler);
            //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return http;//new HttpClient(clientHandler);
        }
    }
}
