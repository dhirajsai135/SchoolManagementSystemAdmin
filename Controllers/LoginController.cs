namespace SchoolManagementSystemAdmin.Controllers;

public class LoginController : Controller
{
    private readonly ILoginService _loginService;
    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var result = await _loginService.Login(loginRequest);
            return Json(result);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
