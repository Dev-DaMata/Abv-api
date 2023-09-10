//using abv-api.Repository;
using abv_api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TypeUsersRepository>(); //injetando a camada de repositorio
builder.Services.AddScoped<UsersRepository>(); //injetando a camada de repositorio
builder.Services.AddScoped<TeamRepository>();
builder.Services.AddScoped<ReplacementRepository>();
builder.Services.AddScoped<SetsRepository>();
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
