using Microsoft.EntityFrameworkCore;
using Tienda_API.Models;

namespace Tienda_API.Services
{
    public class ArticuloService:IArticuloService
    {
        TiendaContext dbContext;
        public ArticuloService (TiendaContext Context)
        {
            dbContext = Context;
        }

        public IEnumerable<Articulo> Get()
        {
            return dbContext.Articulos;
        }

        public async Task Save(Articulo articulo)
        {
            dbContext.Articulos.Add(articulo);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Articulo articulo)
        {
            dbContext.Entry(articulo).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var articuloActual = dbContext.Articulos.Find(id);

            if (articuloActual != null)
            {
                dbContext.Remove(articuloActual);

                await dbContext.SaveChangesAsync();
            }


        }
    }


    public interface IArticuloService
    {
        IEnumerable<Articulo> Get();
        Task Save(Articulo articulo);
        Task Update(Articulo articulo);
        Task Delete(Guid id);
    }


}
