using System.ComponentModel.DataAnnotations;

namespace Taqueria.Models
{
    public class Platillo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
