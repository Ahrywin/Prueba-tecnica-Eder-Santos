using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tienda_API.Models;
using Tienda_API.Services;

namespace Tienda_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TiendaController : Controller
    {

        TiendaContext dbcontext;
        ITiendaService tiendaService;
        public TiendaController(ITiendaService service, TiendaContext db)
        {
            tiendaService = service;
            dbcontext = db;
        }
        [HttpGet]
        [Route("getALL")]
        public IActionResult Get()
        {
            var tiendas = tiendaService.Get().Select(t =>
        new
        {
            t.TiendaId,
            t.Sucursal,
            t.Direccion,
            t.FechaCreacion,
            t.UserName,
            t.Activo,
            Articulos = t.Articulos.Select(a =>
                new
                {
                    a.ArticuloID,
                    a.Codigo,
                    a.Descripcion,
                    a.Precio,
                    a.Imagen,
                    a.Stock,
                    a.FechaCreacion,
                    a.UserName,
                    a.Activo
                })
        });

            return Ok(tiendas);
        }
        [HttpPost]
        public IActionResult post([FromBody] Tienda tienda)
        {

            if (tienda == null)
            {
                return BadRequest("La tienda no puede ser nula");
            }

            tiendaService.Save(tienda);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult put(Guid id, [FromBody] Tienda tienda)
        {
            tiendaService.Update(id, tienda);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tiendaService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            dbcontext.Database.EnsureCreated();

            return Ok();
        }

    }
}
