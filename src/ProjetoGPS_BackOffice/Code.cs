using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using RestSharp;

using System;
using System.Linq;
using System.Net;

namespace ProjetoGPS_BackOffice.Pages
{
	public class Code
	{
		private bool checkLogin = true;

		private readonly PageModel page;

		public Code(PageModel pm, int appType)
		{
			page = pm;

			this.GetApplications(appType);
		}

		public Code(PageModel pm)
		{
			page = pm;

			checkLogin = false;
		}



		public string ApiEndpoint = "https://papi-testapp2.herokuapp.com/api/";
		//public string ApiEndpoint = "https://localhost:44387/api/";





		public Application[] Applications { get; set; }
		public Application[] Pending { get; set; }
		public Application[] Accepted { get; set; }
		public Application[] Rejected { get; set; }





		public class Application
		{
			public long ID { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
			public string Email { get; set; }
			public string City { get; set; }
			public string Message { get; set; }
			public int State { get; set; }
			public int Type { get; set; }
		}





		public T GET<T>(string url)
		{
			var client = new RestClient(url);
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);
			return JsonConvert.DeserializeObject<T>(response.Content);
		}





		public void Refresh()
		{
			page.Response.Redirect(page.Request.Path);
		}





		public void GetApplications(int type)
		{
			this.Pending = this.GET<Application[]>(ApiEndpoint + $"applications/list/{type}/0");
			this.Accepted = this.GET<Application[]>(ApiEndpoint + $"applications/list/{type}/1");
			this.Rejected = this.GET<Application[]>(ApiEndpoint + $"applications/list/{type}/2");

			this.Applications = this.Pending.Concat(this.Accepted).Concat(this.Rejected).ToArray();
		}





		public void UpdateApplication(string action, int app_id)
		{
			Application[] app = this.Applications.Where(p => p.ID == Convert.ToInt32(app_id)).ToArray();

			if (app.Length > 0)
			{
				Application a = app[0];
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

			this.Refresh();
		}





		private void UpdateApplicationState(Application app, int newCode)
		{
			app.State = newCode;

			RestClient client = new RestClient(ApiEndpoint + "applications/" + app.ID);
			client.Timeout = -1;

			RestRequest request = new RestRequest(Method.PUT);
			request.AddHeader("Content-Type", "application/json");

			string body = JsonConvert.SerializeObject(app);
			request.AddParameter("application/json", body, ParameterType.RequestBody);
			client.Execute(request);
		}










		public bool Login(string username, string password)
		{
			var client = new RestClient($"https://localhost:44387/api/admins/login/{username}/{password}");
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return true;
			}
			return false;
		}

		public string GetCookie(string key)
		{
			return page.Request.Cookies[key];
		}

		public void SetCookie(string key, string value, double? expireTime)
		{
			CookieOptions option = new CookieOptions();
			if (expireTime.HasValue)
			{
				option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
			}
			else
			{
				option.Expires = DateTime.Now.AddMilliseconds(1);
			}
			page.Response.Cookies.Append(key, value, option);
		}

		public void DeleteCookie(string key)
		{
			page.Response.Cookies.Delete(key);
		}

		public void CheckLogin()
		{
			if (checkLogin == true && this.GetCookie("loggedIn") != "true")
			{
				this.Redirect("/Login");
			}
		}

		public void Redirect(string url)
		{
			page.Response.Redirect(url);
		}
	}
}
