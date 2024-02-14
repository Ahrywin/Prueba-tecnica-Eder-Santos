using Microsoft.EntityFrameworkCore;
using Tienda_API.Models;

namespace Tienda_API
{
    public class TiendaContext : DbContext
    {

        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Tienda> tiendaInitial = new List<Tienda>();

            tiendaInitial.Add(new Tienda()
            {
                TiendaId = Guid.Parse("77893cf8-b536-4532-ad40-ab3851e75627"),
                Sucursal = "Mexico 001",
                Direccion = "Adress",
                FechaCreacion = DateTime.Now,
                UserName = "Eder",
                Activo = true
            });
            tiendaInitial.Add(new Tienda()
            {
                TiendaId = Guid.Parse("87893cf8-b536-4532-ad40-ab3851e75627"),
                Sucursal = "Mexico 001",
                Direccion = "Adress",
                FechaCreacion = DateTime.Now,
                UserName = "Eder",
                Activo = true
            });


            modelBuilder.Entity<Tienda>(tienda =>
            {
                tienda.ToTable("Tienda");
                tienda.HasKey(p => p.TiendaId);



                
                tienda.Property(p => p.Sucursal).IsRequired();
                tienda.Property(p => p.Direccion).IsRequired().HasMaxLength(150);
                tienda.Property(p => p.FechaCreacion).IsRequired();
                tienda.Property(p => p.UserName).IsRequired();
                tienda.Property(p => p.Activo).IsRequired();
                tienda.HasData(tiendaInitial);


            });

            //ARTICULO

            List<Articulo> ArticuloInitial = new List<Articulo>();

            ArticuloInitial.Add(new Articulo()
            {
                ArticuloID = Guid.Parse("26893cf8-b536-4532-ad40-ab3851e75627"),
                TiendaId = Guid.Parse("77893cf8-b536-4532-ad40-ab3851e75627"),
                Codigo = "1001",
                Descripcion = "TV Smart",
                Precio = 4500.05,
                Imagen = "ss",
                Stock = 10,
                FechaCreacion = DateTime.Now,
                UserName = "Eder",
                Activo = true

            });
            ArticuloInitial.Add(new Articulo()
            {
                ArticuloID = Guid.Parse("36893cf8-b536-4532-ad40-ab3851e75627"),
                TiendaId = Guid.Parse("87893cf8-b536-4532-ad40-ab3851e75627"),
                Codigo = "1001",
                Descripcion = "TV Smart",
                Precio = 4500.05,
                Imagen = "ss",
                Stock = 10,
                FechaCreacion = DateTime.Now,
                UserName = "Eder",
                Activo = true

            });

            modelBuilder.Entity<Articulo>(articulo =>
            {
                articulo.ToTable("Articulo");
                articulo.HasKey(p => p.ArticuloID);

                articulo
                .HasOne(p => p.Tienda)
                .WithMany(p => p.Articulos)
                .HasForeignKey(p => p.TiendaId)
                .OnDelete(DeleteBehavior.Restrict); // Esto evita que se eliminen las tiendas relacionadas con los artículos


                articulo.Property(p => p.Codigo).IsRequired().HasMaxLength(4);
                articulo.Property(p => p.Descripcion).IsRequired().HasMaxLength(150);
                articulo.Property(p => p.Precio).IsRequired();
                articulo.Property(p => p.Imagen).IsRequired(false);
                articulo.Property(p => p.Stock).IsRequired();
                articulo.Property(p => p.FechaCreacion).IsRequired();
                articulo.Property(p => p.UserName).IsRequired();
    
               articulo.HasData(ArticuloInitial);


            });

            // Cliente
           
            List<Cliente> clienteInitial = new List<Cliente>();

            clienteInitial.Add(new Cliente()
            {
                ClienteId= Guid.Parse("88883cf8-b536-4532-ad40-ab3851e75627"),
                TiendaId = Guid.Parse("87893cf8-b536-4532-ad40-ab3851e75627"),
                Nombre ="EDER",
                Apellidos="Santos",
                Direccion="direccion123"
            });
                   

              
            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.ToTable("Cliente");
                cliente.HasKey(p => p.ClienteId);

                cliente
                .HasOne(p => p.Tienda)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.TiendaId);
             

                cliente.Property(p => p.Nombre).IsRequired();
                cliente.Property(p => p.Apellidos).IsRequired();
                cliente.Property(p=>p.Direccion).IsRequired();
                cliente.HasData(clienteInitial);
            });
        




        }
    }
}
