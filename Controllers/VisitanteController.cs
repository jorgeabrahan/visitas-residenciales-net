using Microsoft.AspNetCore.Mvc;
using visitas_residenciales.Models;
using visitas_residenciales.Services;

namespace visitas_residenciales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitanteController : ControllerBase
{
  IVisitanteService visitanteService;
  public VisitanteController(IVisitanteService serviceVisitante)
  {
    visitanteService = serviceVisitante;
  }

  [HttpPost]
  public IActionResult crearVisitante([FromBody] Visitante visitante)
  {
    visitanteService.crear(visitante);
    return Ok();
  }

  //READ
  [HttpGet]
  public IActionResult mostrarVisitantes()
  {
    return Ok(visitanteService.obtener());
  }

  //UPDATE
  [HttpPut("{id}")]
  public IActionResult actualizarVisitante([FromBody] Visitante visitante, Guid id)
  {
    visitanteService.actualizar(id, visitante);
    return Ok();
  }

  //DELETE
  [HttpDelete("{id}")]
  public IActionResult eliminarVisitante(Guid id)
  {
    visitanteService.eliminar(id);
    return Ok();
  }
}
