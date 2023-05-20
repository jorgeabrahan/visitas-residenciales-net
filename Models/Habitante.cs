using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace visitas_residenciales.Models;

public class Habitante
{
  [Key]
  public Guid HabitanteId { get; set; }

  [ForeignKey("CasaId")]
  public Guid CasaId { get; set; }

  [ForeignKey("ResidenteId")]
  public Guid ResidenteId { get; set; }

  [MaxLength(250)]
  public String? Parentesco { get; set; }

  public virtual Casa? Casa { get; set; }
  public virtual Residente? Residente { get; set; }
}