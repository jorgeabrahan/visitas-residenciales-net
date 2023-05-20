using Microsoft.AspNetCore.Mvc;
using visitas_residenciales.Models;
using visitas_residenciales.Services;

namespace visitas_residenciales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitanteController : ControllerBase
{
  IHabitanteService habitanteService;
  public HabitanteController(IHabitanteService serviceHabitante)
  {
    habitanteService = serviceHabitante;
  }

  [HttpPost]
  public IActionResult crearHabitante([FromBody] Habitante habitante)
  {
    habitanteService.crear(habitante);
    return Ok();
  }

  //READ
  [HttpGet]
  public IActionResult mostrarHabitantes()
  {
    return Ok(habitanteService.obtener());
  }

  //UPDATE
  [HttpPut("{id}")]
  public IActionResult actualizarHabitante([FromBody] Habitante habitante, Guid id)
  {
    habitanteService.actualizar(id, habitante);
    return Ok();
  }

  //DELETE
  [HttpDelete("{id}")]
  public IActionResult eliminarHabitante(Guid id)
  {
    habitanteService.eliminar(id);
    return Ok();
  }
}
