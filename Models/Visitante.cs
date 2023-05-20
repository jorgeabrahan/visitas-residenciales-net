using System.ComponentModel.DataAnnotations;

namespace visitas_residenciales.Models;

public class Visitante
{
  [Key]
  public Guid VisitanteId { get; set; }

  [Required]
  public int Identificacion { get; set; }

  [MaxLength(250)]
  public String? Nombre { get; set; }

  public Boolean Sexo { get; set; }

  [Required]
  public int Edad { get; set; }
}