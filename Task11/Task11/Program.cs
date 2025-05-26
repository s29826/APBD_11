using Microsoft.EntityFrameworkCore;
using Task11.Data;
using Task11.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();