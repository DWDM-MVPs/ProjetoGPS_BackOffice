using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoGPS_BackOffice.Pages.Pages
{
	public class DefinicoesModel : PageModel
	{
		public Code code;

		public DefinicoesModel()
		{
			code = new Code(this);
		}

		public void OnGet()
		{
			code.CheckLogin();
		}

		public void OnPostSave()
		{

		}

		public void OnPostRestore()
		{
			code.Refresh();
		}
	}
}
