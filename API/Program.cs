using MySql.Data.MySqlClient;
using Services.DataAccess.BaseDao;
using Services.DataAccess.DbManager;
using Services.Repositories.PersonRepo;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbProvider, MySqlDbProvider>();
builder.Services.AddScoped<IDao, DaoImpl>();
builder.Services.AddScoped<IPersonRepo, PersonRepoImpl>();
builder.Services.AddScoped<DbConnection, MySqlConnection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
