using cookies_authentication.DB;
using cookies_authentication.DB.Tables;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace cookies_authentication.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly PostgreDbContext _context;

        public LoginModel(PostgreDbContext _context)
        {
            this._context = _context;
            this._context.Database.EnsureCreated();
        }

        [BindProperty(Name = "userName")]
        public string? userName { get; set; }

        [BindProperty(Name = "password")]
        public string? Password { get; set; }

        public IActionResult OnGet()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return Redirect("/secure");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost() {

            UsersTable? userByName = _context?.Users?.FirstOrDefault(u => u.UserName == userName);
            if (userByName == null || userByName.Password != Password) {
                ModelState.AddModelError("login-error", "user not found");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Page();
            }

            var userId = userByName.Id;
            var claims = new List<Claim>
            {
                new Claim("sub", userId.ToString()),
                new Claim("name", userName ?? "")
            };
            var identity = new ClaimsIdentity(claims, "cookieAuth", "name", "user");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);
            return Redirect("/secure");
        }
    }
}
