using System.Text.Json.Serialization;

namespace Tienda_API.Models
{
    public class Tienda
    {
        public Guid TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UserName { get; set; }
        public bool Activo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Articulo>? Articulos { get; set; }
        [JsonIgnore]
        public ICollection<Cliente>? Clientes { get; set; }

    }
}
