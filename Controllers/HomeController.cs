using Microsoft.AspNetCore.Mvc;

namespace visitas_residenciales.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  VisitasResidencialesContext dbcontext;
  public HomeController(VisitasResidencialesContext db)
  {
    dbcontext = db;
  }

  [HttpGet]
  [Route("conectar")]
  public IActionResult conectar()
  {
    dbcontext.Database.EnsureCreated();
    return Ok();
  }
}