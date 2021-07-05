using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;

namespace ProjetoGPS_BackOffice.Pages
{
	public class LogoutModel : PageModel
	{
		public Code code;

		public LogoutModel()
		{
			code = new Code(this);
		}

		public void OnGet()
		{
			code.DeleteCookie("loggedIn");
			code.Redirect("/Login");
		}
	}
}
