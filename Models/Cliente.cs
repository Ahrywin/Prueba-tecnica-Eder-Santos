using System.Text.Json.Serialization;
using Tienda_API.Models;

namespace Tienda_API.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public Guid TiendaId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        [JsonIgnore]
     
        public virtual ICollection<Articulo>? articulosCliente { get; set; } // Relación muchos-a-muchos con Articulo
        [JsonIgnore]
        public virtual Tienda? Tienda { get; set; }
    }



}


