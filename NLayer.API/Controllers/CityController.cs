using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ICityService _service;

		public CityController(ICityService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var cities = await _service.GetAllAsync();
			if (cities == null)
				throw new Exception("Veriler bulunamadı!");
			return Ok(cities);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var cities = await _service.GetByIdAsync(id);
			return Ok(cities);
		}

		[HttpPost]
		public async Task<IActionResult> Create(City city)
		{
			await _service.AddAsync(city);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(City city)
		{
			await _service.UpdateAsync(city);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _service.GetByIdAsync(id);
			if (data == null)
				throw new Exception("Bu id'ye sahip veri bulunamadı!");

			await _service.RemoveAsync(data);

			return Ok(data);
		}
	}
}
