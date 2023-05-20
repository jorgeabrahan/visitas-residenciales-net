using Microsoft.AspNetCore.Mvc;
using visitas_residenciales.Models;
using visitas_residenciales.Services;

namespace visitas_residenciales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResidenteController : ControllerBase
{
  IResidenteService residenteService;
  public ResidenteController(IResidenteService serviceResidente)
  {
    residenteService = serviceResidente;
  }

  [HttpPost]
  public IActionResult crearResidente([FromBody] Residente residente)
  {
    residenteService.crear(residente);
    return Ok();
  }

  //READ
  [HttpGet]
  public IActionResult mostrarResidentes()
  {
    return Ok(residenteService.obtener());
  }

  //UPDATE
  [HttpPut("{id}")]
  public IActionResult actualizarResidente([FromBody] Residente residente, Guid id)
  {
    residenteService.actualizar(id, residente);
    return Ok();
  }

  //DELETE
  [HttpDelete("{id}")]
  public IActionResult eliminarResidente(Guid id)
  {
    residenteService.eliminar(id);
    return Ok();
  }
}
