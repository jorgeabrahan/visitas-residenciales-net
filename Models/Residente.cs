using System.ComponentModel.DataAnnotations;

namespace visitas_residenciales.Models;

public class Residente
{
  [Key]
  public Guid ResidenteId { get; set; }

  [Required]
  public int Identificacion { get; set; }

  [MaxLength(250)]
  public String? Nombre { get; set; }

  [Required]
  public int Telefono { get; set; }
}