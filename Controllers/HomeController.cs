namespace SchoolManagementSystemAdmin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("BaseUrl");
        var response = await client.GetAsync("api/Students/GetAll");
        var result = response.Content.ReadAsStringAsync();
        var example = JsonConvert.DeserializeObject<List<StudentVM>>(result.Result);
        return View(example);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}