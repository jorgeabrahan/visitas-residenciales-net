using visitas_residenciales.Models;
namespace visitas_residenciales.Services;

public class VisitanteService : IVisitanteService
{
  VisitasResidencialesContext context;
  public VisitanteService(VisitasResidencialesContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Visitante visitante)
  {
    visitante.VisitanteId = Guid.NewGuid();
    await context.AddAsync(visitante);
    await context.SaveChangesAsync();
  }

  //READ - Obtener de la DB
  public IEnumerable<Visitante>? obtener()
  {
    return context.Visitante;
  }

  public async Task actualizar(Guid id, Visitante actualizado)
  {
    var visitante = context.Visitante?.Find(id);
    if (visitante == null) return;
    visitante.Identificacion = actualizado.Identificacion;
    visitante.Nombre = actualizado.Nombre;
    visitante.Sexo = actualizado.Sexo;
    visitante.Edad = actualizado.Edad;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var visitante = context.Visitante?.Find(id);
    if (visitante == null) return;
    context.Remove(visitante);
    await context.SaveChangesAsync();
  }
}

public interface IVisitanteService
{
  Task crear(Visitante visitante);
  IEnumerable<Visitante>? obtener();
  Task actualizar(Guid id, Visitante actualizado);
  Task eliminar(Guid id);
}
