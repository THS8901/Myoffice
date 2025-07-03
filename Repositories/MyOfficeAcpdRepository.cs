using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyOffice.Repositories;

namespace MyOfficeAcpdApi.Repositories
{
	public class MyOfficeAcpdRepository : IMyOfficeAcpdRepository
	{
		private readonly DbContext _db;
		public MyOfficeAcpdRepository(DbContext db) => _db = db;

		private async Task<string> ExecuteSpAsync(string spName, string jsonIn)
		{
			await _db.Database.OpenConnectionAsync();
			using var cmd = _db.Database.GetDbConnection().CreateCommand();
			cmd.CommandText = spName;
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add(new SqlParameter("@jsonIn", SqlDbType.NVarChar, -1) { Value = jsonIn });
			var pOut = new SqlParameter("@jsonOut", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
			cmd.Parameters.Add(pOut);

			await cmd.ExecuteNonQueryAsync();
			return pOut.Value as string ?? "";
		}

		public Task<string> SelectAsync(string jsonIn)
			=> ExecuteSpAsync("usp_SelectMyOfficeACPD", jsonIn);

		public Task<string> InsertAsync(string jsonIn)
			=> ExecuteSpAsync("usp_InsertMyOfficeACPD", jsonIn);

		public Task<string> UpdateAsync(string jsonIn)
			=> ExecuteSpAsync("usp_UpdateMyOfficeACPD", jsonIn);

		public Task<string> DeleteAsync(string jsonIn)
			=> ExecuteSpAsync("usp_DeleteMyOfficeACPD", jsonIn);
	}
}