using Newtonsoft.Json;
using RealEstateData.Platforms.Android;
using System.Text;

namespace RealEstateApp.Services
{
    public class APIService
    {
        private readonly string _baseUrl;
        public APIService()
        {
            _baseUrl = "https://localhost:7118/api/";
        }

        public async Task<bool> RegisterUser(string name, string email, string password, string phone)
        {
            var endpoint = "users/Register";

            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
                Phone = phone
            };

            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_baseUrl + endpoint, content);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> Login(string email, string password)
        {
            var endpoint = "users/login";

            var login = new Login() { Email = email, Password = password };
            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_baseUrl + endpoint, content);
            if (!response.IsSuccessStatusCode)
                return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var loginResp = JsonConvert.DeserializeObject<Token>(jsonResult);

            //Isolated storage
            Preferences.Set("accesstoken", loginResp.AccessToken);
            Preferences.Set("userid", loginResp.UserId);
            Preferences.Set("username", loginResp.Username);
            return true;

        }
    }
}
