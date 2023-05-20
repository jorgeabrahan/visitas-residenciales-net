using visitas_residenciales.Models;
namespace visitas_residenciales.Services;

public class ResidenteService : IResidenteService
{
  VisitasResidencialesContext context;
  public ResidenteService(VisitasResidencialesContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Residente residente)
  {
    residente.ResidenteId = Guid.NewGuid();
    await context.AddAsync(residente);
    await context.SaveChangesAsync();
  }

  //READ - Obtener de la DB
  public IEnumerable<Residente>? obtener()
  {
    return context.Residente;
  }

  public async Task actualizar(Guid id, Residente actualizado)
  {
    var residente = context.Residente?.Find(id);
    if (residente == null) return;
    residente.Identificacion = actualizado.Identificacion;
    residente.Nombre = actualizado.Nombre;
    residente.Telefono = actualizado.Telefono;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var residente = context.Residente?.Find(id);
    if (residente == null) return;
    context.Remove(residente);
    await context.SaveChangesAsync();
  }
}

public interface IResidenteService
{
  Task crear(Residente residente);
  IEnumerable<Residente>? obtener();
  Task actualizar(Guid id, Residente actualizado);
  Task eliminar(Guid id);
}
