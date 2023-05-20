using System.ComponentModel.DataAnnotations;

namespace visitas_residenciales.Models;

public class Casa
{
  [Key]
  public Guid CasaId { get; set; }

  [Required]
  public int Numero { get; set; }

  [Required]
  public int Bloque { get; set; }

  [Required]
  public int Calle { get; set; }

  [MaxLength(250)]
  public String? Referencia { get; set; }
}