using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLayer.Core.Models;
using System.Net.Http.Headers;
using System.Text;

namespace NLayer.Web.Controllers
{
	public class CityController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CityController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;

		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7270/api/City");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<City>>(jsonData);

				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult AddCity()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddCity(City city)
		{
			if (ModelState.IsValid)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(city);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var messageResponse = await client.PostAsync("https://localhost:7270/api/City", stringContent);
				if (messageResponse.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
				return View();
			}
			return View(city);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCity(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7270/api/City/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<City>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCity(City city)
		{
			if(ModelState.IsValid) { 
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(city);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var messageResponse = await client.PutAsync("https://localhost:7270/api/City", stringContent);
			if (messageResponse.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
			}

			return View(city);
		}

		public async Task<IActionResult> DeleteCity(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7270/api/City?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}


	}
}
