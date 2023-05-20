using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace visitas_residenciales.Models;

public class Visita
{
  [Key]
  public Guid VisitaId { get; set; }

  [ForeignKey("VisitanteId")]
  public Guid VisitanteId { get; set; }

  [ForeignKey("CasaId")]
  public Guid CasaId { get; set; }

  [MaxLength(250)]
  public String? FechaEntrada { get; set; }

  [MaxLength(250)]
  public String? FechaSalida { get; set; }

  public String? CodigoQR { get; set; }

  public Boolean Estado { get; set; }

  public virtual Visitante? Visitante { get; set; }
  public virtual Casa? Casa { get; set; }
}