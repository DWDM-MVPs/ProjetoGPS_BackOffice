using Microsoft.AspNetCore.Mvc.RazorPages;

using static ProjetoGPS_BackOffice.Pages.Code;

namespace ProjetoGPS_BackOffice.Pages.Pages
{
	public class DefinicoesModel : PageModel
	{
		public Admin admin;
		public Placeholders about;
		public Placeholders t1n;
		public Placeholders t1d;
		public Placeholders t2n;
		public Placeholders t2d;
		public Placeholders t3n;
		public Placeholders t3d;
		public Placeholders cIpsEmail;
		public Placeholders cIpsTel;
		public Placeholders cIpsWeb;
		public Placeholders cIpvEmail;
		public Placeholders cIpvTel;
		public Placeholders cIpvWeb;
		public Placeholders cIplEmail;
		public Placeholders cIplTel;
		public Placeholders cIplWeb;
		public Placeholders iAbout;
		public Placeholders iWhere;
		public Placeholders iWhy;

		public Code code;

		public DefinicoesModel()
		{
			code = new Code(this);

			admin = code.GET<Admin>("admins");
			about = code.GET<Placeholders>("placeholders/About");
			t1n = code.GET<Placeholders>("placeholders/Testemunho1Nome");
			t1d = code.GET<Placeholders>("placeholders/Testemunho1Descricao");
			t2n = code.GET<Placeholders>("placeholders/Testemunho2Nome");
			t2d = code.GET<Placeholders>("placeholders/Testemunho2Descricao");
			t3n = code.GET<Placeholders>("placeholders/Testemunho3Nome");
			t3d = code.GET<Placeholders>("placeholders/Testemunho3Descricao");
			cIpsEmail = code.GET<Placeholders>("placeholders/ContactosIPSEmail");
			cIpsTel = code.GET<Placeholders>("placeholders/ContactosIPSTelefone");
			cIpsWeb = code.GET<Placeholders>("placeholders/ContactosIPSWebsite");
			cIpvEmail = code.GET<Placeholders>("placeholders/ContactosIPVEmail");
			cIpvTel = code.GET<Placeholders>("placeholders/ContactosIPVTelefone");
			cIpvWeb = code.GET<Placeholders>("placeholders/ContactosIPVWebsite");
			cIplEmail = code.GET<Placeholders>("placeholders/ContactosIPLEmail");
			cIplTel = code.GET<Placeholders>("placeholders/ContactosIPLTelefone");
			cIplWeb = code.GET<Placeholders>("placeholders/ContactosIPLWebsite");
			iAbout = code.GET<Placeholders>("placeholders/IndexAbout");
			iWhere = code.GET<Placeholders>("placeholders/IndexWhere");
			iWhy = code.GET<Placeholders>("placeholders/IndexWhy");
		}

		public void OnGet()
		{
			code.CheckLogin();
		}

		public void OnPostSave()
		{
			admin.Username = this.Request.Form["username"];
			admin.Password = this.Request.Form["password"];
			code.PUT($"admins/{admin.ID}", admin);

			about.Value = this.Request.Form["about"];
			code.PUT($"placeholders/{about.Placeholder}", about);

			t1n.Value = this.Request.Form["t1n"];
			code.PUT($"placeholders/{t1n.Placeholder}", t1n);
			t1d.Value = this.Request.Form["t1d"];
			code.PUT($"placeholders/{t1d.Placeholder}", t1d);

			t2n.Value = this.Request.Form["t2n"];
			code.PUT($"placeholders/{t2n.Placeholder}", t2n);
			t2d.Value = this.Request.Form["t2d"];
			code.PUT($"placeholders/{t2d.Placeholder}", t2d);

			t3n.Value = this.Request.Form["t3n"];
			code.PUT($"placeholders/{t3n.Placeholder}", t3n);
			t3d.Value = this.Request.Form["t3d"];
			code.PUT($"placeholders/{t3d.Placeholder}", t3d);

			cIpsEmail.Value = this.Request.Form["cIpsEmail"];
			code.PUT($"placeholders/{cIpsEmail.Placeholder}", cIpsEmail);
			cIpsTel.Value = this.Request.Form["cIpsTel"];
			code.PUT($"placeholders/{cIpsTel.Placeholder}", cIpsTel);
			cIpsWeb.Value = this.Request.Form["cIpsWeb"];
			code.PUT($"placeholders/{cIpsWeb.Placeholder}", cIpsWeb);

			cIpvEmail.Value = this.Request.Form["cIpvEmail"];
			code.PUT($"placeholders/{cIpvEmail.Placeholder}", cIpvEmail);
			cIpvTel.Value = this.Request.Form["cIpvTel"];
			code.PUT($"placeholders/{cIpvTel.Placeholder}", cIpvTel);
			cIpvWeb.Value = this.Request.Form["cIpvWeb"];
			code.PUT($"placeholders/{cIpvWeb.Placeholder}", cIpvWeb);

			cIplEmail.Value = this.Request.Form["cIplEmail"];
			code.PUT($"placeholders/{cIplEmail.Placeholder}", cIplEmail);
			cIplTel.Value = this.Request.Form["cIplTel"];
			code.PUT($"placeholders/{cIplTel.Placeholder}", cIplTel);
			cIplWeb.Value = this.Request.Form["cIplWeb"];
			code.PUT($"placeholders/{cIplWeb.Placeholder}", cIplWeb);

			iAbout.Value = this.Request.Form["iAbout"];
			code.PUT($"placeholders/{iAbout.Placeholder}", iAbout);
			iWhere.Value = this.Request.Form["iWhere"];
			code.PUT($"placeholders/{iWhere.Placeholder}", iWhere);
			iWhy.Value = this.Request.Form["iWhy"];
			code.PUT($"placeholders/{iWhy.Placeholder}", iWhy);

			code.Refresh();
		}

		public void OnPostRestore()
		{
			code.Refresh();
		}
	}
}
