using BackEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//asi inyectamos la interfaz y la clase que la implementa para poder
//usarla en los controladores
//builder.Services.AddSingleton<IPeopleServices, People2Services>();

// Ejemplo de inyeccion de dependencias con llave
builder.Services.AddKeyedSingleton<IPeopleServices, PeopleServices>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleServices, People2Services>("people2Service");


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
