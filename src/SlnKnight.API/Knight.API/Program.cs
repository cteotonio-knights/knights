using Knight.API.Config;
using Knight.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do MongoDB
var mongoConfig = MongoDBConfig.Connect(builder.Configuration);
builder.Services.AddSingleton(mongoConfig);

// Registro da injeção de dependência para o repositório
builder.Services.AddTransient<IKnightRepository, KnightRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Serviço Knight v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
