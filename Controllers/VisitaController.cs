using Microsoft.AspNetCore.Mvc;
using visitas_residenciales.Models;
using visitas_residenciales.Services;

namespace visitas_residenciales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitaController : ControllerBase
{
  IVisitaService visitaService;
  public VisitaController(IVisitaService serviceVisita)
  {
    visitaService = serviceVisita;
  }

  [HttpPost]
  public IActionResult crearVisita([FromBody] Visita visita)
  {
    visitaService.crear(visita);
    return Ok();
  }

  //READ
  [HttpGet]
  public IActionResult mostrarVisitas()
  {
    return Ok(visitaService.obtener());
  }

  //UPDATE
  [HttpPut("{id}")]
  public IActionResult actualizarVisita([FromBody] Visita visita, Guid id)
  {
    visitaService.actualizar(id, visita);
    return Ok();
  }

  //DELETE
  [HttpDelete("{id}")]
  public IActionResult eliminarVisita(Guid id)
  {
    visitaService.eliminar(id);
    return Ok();
  }
}
