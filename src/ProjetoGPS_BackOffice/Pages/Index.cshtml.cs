using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoGPS_BackOffice.Pages
{
	public class IndexModel : PageModel
	{
		public Code code;

		public IndexModel()
		{
			code = new Code(this, 0);
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
