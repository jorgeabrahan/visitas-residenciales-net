using visitas_residenciales;
using visitas_residenciales.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<VisitasResidencialesContext>("Data Source=localhost; Initial Catalog=visitasDB;user id=sa;password=Programaci0n$;Encrypt=False");
builder.Services.AddScoped<ICasaService, CasaService>();
builder.Services.AddScoped<IHabitanteService, HabitanteService>();
builder.Services.AddScoped<IResidenteService, ResidenteService>();
builder.Services.AddScoped<IVisitaService, VisitaService>();
builder.Services.AddScoped<IVisitanteService, VisitanteService>();

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
