
var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddScoped<ILoginService, LoginService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("BaseUrl", c => { c.BaseAddress = new Uri("https://localhost:7044"); });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
