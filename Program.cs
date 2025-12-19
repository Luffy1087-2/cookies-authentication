using cookies_authentication.DB;
using DotEnv.Core;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
new EnvLoader().Load();
builder.Services.AddDbContext<PostgreDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(defaultScheme: "Cookie")
    .AddCookie(authenticationScheme: "Cookie", (opt) =>
    {
        opt.Cookie.Name = "cookieName";
        opt.ExpireTimeSpan = TimeSpan.FromHours(8);
        opt.LoginPath = "/Login";
    });

WebApplication app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages()
    .RequireAuthorization();
app.MapGet("/", () => Results.Redirect("/login"));
app.Run();
