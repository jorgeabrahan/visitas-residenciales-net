using visitas_residenciales.Models;
namespace visitas_residenciales.Services;

public class VisitaService : IVisitaService
{
  VisitasResidencialesContext context;
  public VisitaService(VisitasResidencialesContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Visita visita)
  {
    visita.VisitaId = Guid.NewGuid();
    await context.AddAsync(visita);
    await context.SaveChangesAsync();
  }

  //READ - Obtener de la DB
  public IEnumerable<Visita>? obtener()
  {
    return context.Visita;
  }

  public async Task actualizar(Guid id, Visita actualizado)
  {
    var visita = context.Visita?.Find(id);
    if (visita == null) return;
    visita.FechaEntrada = actualizado.FechaEntrada;
    visita.FechaSalida = actualizado.FechaSalida;
    visita.CodigoQR = actualizado.CodigoQR;
    visita.Estado = actualizado.Estado;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var visita = context.Visita?.Find(id);
    if (visita == null) return;
    context.Remove(visita);
    await context.SaveChangesAsync();
  }
}

public interface IVisitaService
{
  Task crear(Visita visita);
  IEnumerable<Visita>? obtener();
  Task actualizar(Guid id, Visita actualizado);
  Task eliminar(Guid id);
}
