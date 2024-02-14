using System.Text.Json.Serialization;

namespace Tienda_API.Models
{
    public class Articulo
    {
        public Guid ArticuloID { get; set; }
        public Guid TiendaId { get; set; }
        public Guid? ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UserName { get; set; }
        public bool Activo { get; set; }
        [JsonIgnore]
        public virtual Tienda? Tienda { get; set; }
     
    }


}
