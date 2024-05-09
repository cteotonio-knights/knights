using Knight.API.Config;
using Knight.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do MongoDB
var mongoConfig = MongoDBConfig.Connect(builder.Configuration);
builder.Services.AddSingleton(mongoConfig);

// Registro da inje��o de depend�ncia para o reposit�rio
builder.Services.AddTransient<IKnightRepository, KnightRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Servi�o Knight v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
