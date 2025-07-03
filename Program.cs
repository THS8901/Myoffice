using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyOffice.Repositories;
using MyOfficeAcpdApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. 註冊 DbContext，只為了拿到 DatabaseFacade 連線
builder.Services.AddDbContext<DbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 2. 註冊 Repository
builder.Services.AddScoped<IMyOfficeAcpdRepository, MyOfficeAcpdRepository>();

// 3. 註冊 Controllers 與 Swagger
builder.Services
	.AddControllers()
	.AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. 中介軟體管線
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
