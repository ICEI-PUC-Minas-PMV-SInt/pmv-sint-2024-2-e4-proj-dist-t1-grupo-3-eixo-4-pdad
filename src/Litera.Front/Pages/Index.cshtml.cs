using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Litera.Front.Pages
{
    public class IndexModel : PageModel
    {

        public void OnGet()
        {
            ViewData["ApiUrl"] = Environment.GetEnvironmentVariable("API_URL") ?? "http://localhost:5233";
        }
    }
}
