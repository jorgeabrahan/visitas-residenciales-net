using visitas_residenciales.Models;
namespace visitas_residenciales.Services;

public class HabitanteService : IHabitanteService
{
  VisitasResidencialesContext context;
  public HabitanteService(VisitasResidencialesContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Habitante habitante)
  {
    habitante.HabitanteId = Guid.NewGuid();
    await context.AddAsync(habitante);
    await context.SaveChangesAsync();
  }

  //READ - Obtener de la DB
  public IEnumerable<Habitante>? obtener()
  {
    return context.Habitante;
  }

  public async Task actualizar(Guid id, Habitante actualizado)
  {
    var habitante = context.Habitante?.Find(id);
    if (habitante == null) return;
    habitante.Parentesco = actualizado.Parentesco;
    habitante.Casa = actualizado.Casa;
    habitante.Residente = actualizado.Residente;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var habitante = context.Habitante?.Find(id);
    if (habitante == null) return;
    context.Remove(habitante);
    await context.SaveChangesAsync();
  }
}

public interface IHabitanteService
{
  Task crear(Habitante habitante);
  IEnumerable<Habitante>? obtener();
  Task actualizar(Guid id, Habitante actualizado);
  Task eliminar(Guid id);
}
