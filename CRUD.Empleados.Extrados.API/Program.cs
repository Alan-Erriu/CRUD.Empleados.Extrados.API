using Configurations;
using CRUD.Empleados.Extrados.Data.Implementations;
using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Services.Implementations;
using CRUD.Empleados.Extrados.Services.Interfaces;
using PlanItUp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//---------config----------------//
builder.Services.Configure<SQLServerConfig>(builder.Configuration.GetSection("DBTestConnection"));
//---------dependenciesDATA---------//
builder.Services.AddScoped<IAuthDAO, AuthDAO>();
//---------dependenciesServices-----//
builder.Services.AddScoped<IAuthServices, AuthServices>();
//---------endDpendencies-----------//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
