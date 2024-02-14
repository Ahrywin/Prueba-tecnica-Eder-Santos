using Microsoft.EntityFrameworkCore;
using Tienda_API.Models;

namespace Tienda_API.Services
{
    public class ClienteService:IClienteService
    {
        TiendaContext context;
        public ClienteService(TiendaContext dbcontext)
        {
            context = dbcontext;

        }

        public IEnumerable<Cliente> Get()
        {
            return context.Clientes.Include(p=>p.articulosCliente);
        }
        public async Task Save(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            context.Entry(cliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var usuarioActual = context.Clientes.Find(id);

            if (usuarioActual != null)
            {
                context.Clientes.Remove(usuarioActual);

                await context.SaveChangesAsync();
            }
     
        }


    }

    public interface IClienteService 
    {
        IEnumerable<Cliente> Get();
        Task Save(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Guid id);
    }


}
