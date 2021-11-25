using System.ComponentModel.DataAnnotations;

namespace Taqueria.Models
{
    public class Tarjeta
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Numero { get; set; }
        public string FechaExpiracion { get; set; }
    }
}
