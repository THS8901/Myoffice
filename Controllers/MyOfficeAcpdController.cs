using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyOffice.Repositories;
using MyOfficeAcpdApi.Repositories;

namespace MyOfficeAcpdApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MyOfficeAcpdController : ControllerBase
	{
		private readonly IMyOfficeAcpdRepository _repo;
		public MyOfficeAcpdController(IMyOfficeAcpdRepository repo) => _repo = repo;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var json = "{}";
			var result = await _repo.SelectAsync(json);
			return Content(result, "application/json");
		}

		/// <summary>以 JSON 條件查詢 MyOffice_ACPD</summary>
		[HttpPost("select")]
		public async Task<IActionResult> Select([FromBody] JsonElement body)
		{
			var resultJson = await _repo.SelectAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}

		/// <summary>新增一筆 MyOffice_ACPD</summary>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] JsonElement body)
		{
			var resultJson = await _repo.InsertAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}

		/// <summary>更新一筆 MyOffice_ACPD</summary>
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] JsonElement body)
		{
			var resultJson = await _repo.UpdateAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}

		/// <summary>刪除一筆 MyOffice_ACPD</summary>
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] JsonElement body)
		{
			var resultJson = await _repo.DeleteAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}
	}
}