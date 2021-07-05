using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoGPS_BackOffice.Pages
{
	public class LoginModel : PageModel
	{
		public string Cookie { get; set; }
		public Code code;

		public LoginModel()
		{
			code = new Code(this);
		}

		public void OnGet()
		{
			if (code.GetCookie("loggedIn") == "true")
			{
				code.Redirect("/Index");
			}
		}

		public void OnPostLogin()
		{
			string username = this.Request.Form["username"];
			string password = this.Request.Form["password"];

			bool success = code.Login(username, password);

			code.DeleteCookie("loggedIn");
			if (success)
			{
				code.SetCookie("loggedIn", "true", 15.0);

				this.Response.Redirect("/Index");
			}
			else
			{
				code.SetCookie("loggedIn", "false", 15.0);

				code.Refresh();
			}
		}
	}
}
