using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParseManufacturer.Core
{
	public class HtmlLoader
	{
		private readonly HttpClient _client;
		private readonly string _url;
		public HtmlLoader()
		{
			_client = new HttpClient();
		}
		public HtmlLoader(IParseSettings settings)
		{
			_client = new HttpClient();
			_url = $"{settings.BaseUrl}";
		}


		public async Task<string> GetSourceAsync()
		{
			var response = await _client.GetAsync(_url);
			var source = "";
			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}

			return source;
		}		
		
		public async Task<string> GetSourceAsync(string url)
		{
			var response = await _client.GetAsync(url);
			var source = "";
			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}

			return source;
		}
	}
}
