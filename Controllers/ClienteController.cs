using Microsoft.AspNetCore.Mvc;
using Tienda_API.Models;
using Tienda_API.Services;

namespace Tienda_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ClienteController : Controller
    {
        TiendaContext dbcontext;
        IClienteService clienteService;
        public ClienteController(IClienteService service, TiendaContext db)
        {
            clienteService = service;
            dbcontext = db;
        }

        [HttpGet]
        [Route("getALL")]
        public IActionResult Get()
        {
            var clientes = clienteService.Get().Select(t =>
        new
        {
           t.ClienteId,
           t.TiendaId,
           t.Nombre,
           t.Apellidos,
           t.Direccion,
            Articulos = t.articulosCliente.Select(a =>
                new
                {
                   a.ArticuloID,
                   a.Descripcion
                })
        });

            return Ok(clientes);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        { 

            await clienteService.Save(cliente);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("El cliente no puede ser nulo");
            }

            await clienteService.Update(cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            clienteService.Delete(id);
            return Ok();
        }
    }

}
