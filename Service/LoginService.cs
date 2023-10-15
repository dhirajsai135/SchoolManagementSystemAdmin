
using Newtonsoft.Json;

namespace SchoolManagementSystemAdmin.Service;

public class LoginService : ILoginService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public LoginService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseMessageVM> Login(LoginRequest loginRequest)
    {
        var client = _httpClientFactory.CreateClient("BaseUrl");
        var response = await client.PostAsJsonAsync("api/Users/Login", loginRequest);
        var result = response.Content.ReadAsStringAsync();
        var loginResponse = JsonConvert.DeserializeObject<ResponseMessageVM>(result.Result) ?? new ResponseMessageVM();
        return loginResponse;
    }
}
