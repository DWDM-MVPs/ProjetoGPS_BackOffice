using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoGPS_BackOffice.Pages
{
	public class SugestoesModel : PageModel
	{
		public Code code;

		public SugestoesModel()
		{
			code = new Code(this, 2);
		}

		public void OnPostUpdateApplication(string action, int app_id)
		{
			code.UpdateApplication(action, app_id);
		}
	}
}
