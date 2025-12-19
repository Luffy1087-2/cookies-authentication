using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cookies_authentication.Pages
{
    public class SecureModel : PageModel
    {
        public void OnGet()
        {
            if (User.Identity == null || User.Identity.IsAuthenticated == false)
            {
                Redirect("/login");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/login");
        }
    }
}
