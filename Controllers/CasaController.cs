using Microsoft.AspNetCore.Mvc;
using visitas_residenciales.Models;
using visitas_residenciales.Services;

namespace visitas_residenciales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CasaController : ControllerBase
{
  ICasaService casaService;
  public CasaController(ICasaService serviceCasa)
  {
    casaService = serviceCasa;
  }

  [HttpPost]
  public IActionResult crearCasa([FromBody] Casa casa)
  {
    casaService.crear(casa);
    return Ok();
  }

  //READ
  [HttpGet]
  public IActionResult mostrarCasas()
  {
    return Ok(casaService.obtener());
  }

  //UPDATE
  [HttpPut("{id}")]
  public IActionResult actualizarCasa([FromBody] Casa casa, Guid id)
  {
    casaService.actualizar(id, casa);
    return Ok();
  }

  //DELETE
  [HttpDelete("{id}")]
  public IActionResult eliminarCasa(Guid id)
  {
    casaService.eliminar(id);
    return Ok();
  }
}