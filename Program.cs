using empleadovac;
using empleadovac.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<context>("Data Source=localhost; Initial Catalog=vacacionesDB;user id=sa;password=Programaci0n$;Encrypt=False");
builder.Services.AddScoped<IcargoService, cargoService>();
builder.Services.AddScoped<IcodigotrabajoService, codigotrabajoService>();
builder.Services.AddScoped<IempleadoService, empleadoService>();
builder.Services.AddScoped<IvacacionesService, vacacionesService>();

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
