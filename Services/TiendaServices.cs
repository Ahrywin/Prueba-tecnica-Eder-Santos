using Microsoft.EntityFrameworkCore;
using Tienda_API.Models;

namespace Tienda_API.Services
{


    public class TiendaService : ITiendaService
    {
        TiendaContext context;
        public TiendaService(TiendaContext dbcontext)
        {
            context = dbcontext;

        }
        public IEnumerable<Tienda> Get()
        {
            return context.Tiendas .Include(p => p.Articulos);
        }

        public async Task Save(Tienda tienda)
        {
            context.Add(tienda);
            await context.SaveChangesAsync();
        }


        public async Task Update(Guid id, Tienda tienda)
        {
            var tiendaActual = context.Tiendas.Find(id);
          
            if (tiendaActual != null)
            {
                tiendaActual.Sucursal = tienda.Sucursal;
                tiendaActual.Direccion = tienda.Direccion;
                tiendaActual.UserName = tienda.UserName;
                tiendaActual.Activo = tienda.Activo;
                tiendaActual.Articulos= tienda.Articulos;

                await context.SaveChangesAsync();
            }


        }
        public async Task Delete(Guid id)
        {
            var tiendaActual = context.Tiendas.Find(id);
            if (tiendaActual != null)
            {
                context.Remove(tiendaActual);
                await context.SaveChangesAsync();
            }


        }
    }

    public interface ITiendaService
    {
        IEnumerable<Tienda> Get();
        Task Save(Tienda tienda);
        Task Update(Guid id, Tienda tienda);
        Task Delete(Guid id);
    }
}
