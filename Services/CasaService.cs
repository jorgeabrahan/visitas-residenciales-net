using visitas_residenciales.Models;
namespace visitas_residenciales.Services;

public class CasaService : ICasaService
{
  VisitasResidencialesContext context;
  public CasaService(VisitasResidencialesContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Casa casa)
  {
    casa.CasaId = Guid.NewGuid();
    await context.AddAsync(casa);
    await context.SaveChangesAsync();
  }

  //READ - Obtener de la DB
  public IEnumerable<Casa>? obtener()
  {
    return context.Casa;
  }

  public async Task actualizar(Guid id, Casa actualizado)
  {
    var casa = context.Casa?.Find(id);
    if (casa == null) return;
    casa.Numero = actualizado.Numero;
    casa.Bloque = actualizado.Bloque;
    casa.Calle = actualizado.Calle;
    casa.Referencia = actualizado.Referencia;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var casa = context.Casa?.Find(id);
    if (casa == null) return;
    context.Remove(casa);
    await context.SaveChangesAsync();
  }
}

public interface ICasaService
{
  Task crear(Casa casa);
  IEnumerable<Casa>? obtener();
  Task actualizar(Guid id, Casa actualizado);
  Task eliminar(Guid id);
}
