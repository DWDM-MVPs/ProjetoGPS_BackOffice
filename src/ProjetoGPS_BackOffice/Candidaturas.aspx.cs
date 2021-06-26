using Newtonsoft.Json;

using ScriptsLib.Network;

using System;
using System.Web.UI;

namespace ProjetoGPS_BackOffice
{
	public partial class _Default : Page
	{
		public class Applications
		{
			public string Name { get; set; }
			public string Surname { get; set; }
			public string Email { get; set; }
			public string City { get; set; }
			public string Message { get; set; }
		}

		public Applications[] Aps;

		protected void Page_Load(object sender, EventArgs e)
		{
			string req = Requests.GET("https://papi-testapp2.herokuapp.com/api/applications");
			Aps = JsonConvert.DeserializeObject<Applications[]>(req);
		}
	}
}