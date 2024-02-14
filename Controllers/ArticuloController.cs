using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda_API.Models;
using Tienda_API.Services;

namespace Tienda_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ArticuloController:Controller
    {
        TiendaContext dbcontext;
        IArticuloService articuloService;

        public ArticuloController(IArticuloService service, TiendaContext db)
        {
            articuloService = service;
            dbcontext=db;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult Get()
        {
            var articulos = articuloService.Get().Select(t =>
        new
        {
            t.ArticuloID,
            t.TiendaId,
            t.Codigo,
            t.Descripcion,
            t.Precio,
            t.Imagen,
            t.Stock,
            t.FechaCreacion,
            t.UserName,
            t.Activo


        });
         return Ok(articulos);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Articulo articulo)
        {
            if (articulo == null)
            {
                return BadRequest("El articulo no puede ser nulo");
            }

            var existingArticulo = await dbcontext.Articulos.FindAsync(articulo.ArticuloID);
            if (existingArticulo != null)
            {
                return Conflict("No se puede duplicar articulos");
            }

            await articuloService.Save(articulo);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Articulo articulo)
        {
            if (articulo == null)
            {
                return BadRequest("El artículo no puede ser nulo");
            }

            await articuloService.Update(articulo);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            articuloService.Delete(id);
            return Ok();
        }

       
    }
}
