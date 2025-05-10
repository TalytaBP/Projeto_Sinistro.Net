using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjetoSinistroAPI.Services
{
    public interface IExternalAuthService
    {
        Task<bool> AuthenticateUserAsync(string username, string password);
    }

    public class ExternalAuthService : IExternalAuthService
    {
        private readonly HttpClient _httpClient;

        public ExternalAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            // For demonstration, call a mock external API endpoint
            var response = await _httpClient.PostAsJsonAsync("https://mock-auth-service/api/authenticate", new { username, password });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                return result != null && result.IsAuthenticated;
            }

            return false;
        }

        private class AuthResponse
        {
            public bool IsAuthenticated { get; set; }
        }
    }
}
