namespace MyOffice.Repositories
{
	public interface IMyOfficeAcpdRepository
	{
		Task<string> SelectAsync(string jsonIn);
		Task<string> InsertAsync(string jsonIn);
		Task<string> UpdateAsync(string jsonIn);
		Task<string> DeleteAsync(string jsonIn);
	}
}