using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoGPS_BackOffice.Pages
{
	public class DuvidasModel : PageModel
	{
		public Code code;

		public DuvidasModel()
		{
			code = new Code(this, 1);
		}

		public void OnGet()
		{
			code.CheckLogin();
		}

		public void OnPostUpdateApplication(string action, int app_id)
		{
			code.UpdateApplication(action, app_id);
		}
	}
}
