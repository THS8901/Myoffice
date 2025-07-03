using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyOffice.Repositories;
using MyOfficeAcpdApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. ���U DbContext�A�u���F���� DatabaseFacade �s�u
builder.Services.AddDbContext<DbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 2. ���U Repository
builder.Services.AddScoped<IMyOfficeAcpdRepository, MyOfficeAcpdRepository>();

// 3. ���U Controllers �P Swagger
builder.Services
	.AddControllers()
	.AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. �����n��޽u
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
