using Microsoft.EntityFrameworkCore;
using visitas_residenciales.Models;

namespace visitas_residenciales;

public class VisitasResidencialesContext : DbContext
{
  public DbSet<Casa>? Casa { get; set; }
  public DbSet<Habitante>? Habitante { get; set; }
  public DbSet<Residente>? Residente { get; set; }
  public DbSet<Visita>? Visita { get; set; }
  public DbSet<Visitante>? Visitante { get; set; }

  public VisitasResidencialesContext(DbContextOptions<VisitasResidencialesContext> options) : base(options) { }
}