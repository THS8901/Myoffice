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

		/// <summary>查詢 MyOffice_ACPD內所有Data</summary>
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var json = "{}";
			var result = await _repo.SelectAsync(json);
			return Content(result, "application/json");
		}

		/// <summary>以 JSON 條件查詢 MyOffice_ACPD</summary>
		/// <param name="body">
		/// <example>
		/// {
		///   "ACPD_Ename":"test1"
		/// }
		/// </example>
		/// </param>
		[HttpPost("select")]
		public async Task<IActionResult> Select([FromBody] JsonElement body)
		{
			var resultJson = await _repo.SelectAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}

		/// <summary>新增一筆 MyOffice_ACPD</summary>
		/// <param name="body">
		/// <example>
		/// {
		///   "ACPD_Cname":"測試1",
		///   "ACPD_Ename":"test1",
		///   "ACPD_Sname":"t1",
		///   "ACPD_Email":"test1@example.com",
		///   "ACPD_Status":1,
		///   "ACPD_Stop":0,
		///   "ACPD_LoginID":"t001",
		///   "ACPD_LoginPWD":"Pwd123456",
		///   "ACPD_Memo":"測試",
		///   "ACPD_NowID":"admin",
		///   "ACPD_UPDID":"admin"
		/// }
		/// </example>
		/// </param>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] JsonElement body)
		{
			var resultJson = await _repo.InsertAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}

		/// <summary>更新一筆 MyOffice_ACPD</summary>
		/// <param name="body">
		/// <example>
		/// {
		///	  "ACPD_SID": "ACPD2025?????",
		///   "ACPD_Cname":"測試1",
		///   "ACPD_Ename":"test1",
		///   "ACPD_Sname":"t1",
		///   "ACPD_Email":"test1@example.com",
		///   "ACPD_Status":1,
		///   "ACPD_Stop":0,
		///   "ACPD_LoginID":"t001",
		///   "ACPD_LoginPWD":"Pwd123456",
		///   "ACPD_Memo":"測試",
		///   "ACPD_NowID":"admin",
		///   "ACPD_UPDID":"admin"
		/// }
		/// </example>
		/// </param>
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] JsonElement body)
		{
			var resultJson = await _repo.UpdateAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}

		/// <summary>刪除一筆 MyOffice_ACPD</summary>
		/// <param name="body">
		/// <example>
		/// {
		///	  "ACPD_SID": "ACPD2025?????",
		///   "ACPD_Cname":"測試1",
		///   "ACPD_Ename":"test1",
		///   "ACPD_Sname":"t1",
		///   "ACPD_Email":"test1@example.com",
		///   "ACPD_Status":1,
		///   "ACPD_Stop":0,
		///   "ACPD_LoginID":"t001",
		///   "ACPD_LoginPWD":"Pwd123456",
		///   "ACPD_Memo":"測試",
		///   "ACPD_NowID":"admin",
		///   "ACPD_UPDID":"admin"
		/// }
		/// </example>
		/// </param>
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] JsonElement body)
		{
			var resultJson = await _repo.DeleteAsync(body.GetRawText());
			return Content(resultJson, "application/json");
		}
	}
}