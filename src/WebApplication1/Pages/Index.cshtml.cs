using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using RestSharp;

using System;
using System.Linq;

namespace WebApplication1.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			string req = this.GetApplications();
			this.apps = JsonConvert.DeserializeObject<Applications[]>(req);
		}

		public string GetApplications()
		{
			var client = new RestClient("https://localhost:44387/api/applications/list/0");
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);
			return response.Content;

		}

		public class Applications
		{
			public long ID { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
			public string Email { get; set; }
			public string City { get; set; }
			public string Message { get; set; }
			public int State { get; set; }
		}

		public Applications[] apps { get; set; }

		protected void Refresh()
		{
			this.Response.Redirect(Request.Path);
		}

		protected void Alert(string message)
		{
			this.ViewData["alert"] = message;
		}

		public string ApiEndpoint = "https://papi-testapp2.herokuapp.com/api/";
		//public string ApiEndpoint = "https://localhost:44387/api/";

		public void OnPostUpdateApplication(string action, int app_id)
		{
			Applications[] app = this.apps.Where(p => p.ID == Convert.ToInt32(app_id)).ToArray();

			if (app.Length > 0)
			{
				Applications a = app[0];
				if (action == "accept")
				{
					this.UpdateApplicationState(app[0], 1);
				}
				else if (action == "reject")
				{
					this.UpdateApplicationState(app[0], 2);
				}
				else if (action == "restore")
				{
					this.UpdateApplicationState(app[0], 0);
				}
			}
		}

		public void UpdateApplicationState(Applications app, int newCode)
		{
			app.State = newCode;

			RestClient client = new RestClient(ApiEndpoint + "applications/" + app.ID);
			client.Timeout = -1;

			RestRequest request = new RestRequest(Method.PUT);
			request.AddHeader("Content-Type", "application/json");

			string body = JsonConvert.SerializeObject(app);
			request.AddParameter("application/json", body, ParameterType.RequestBody);
			client.Execute(request);

			this.Refresh();
		}
	}
}
