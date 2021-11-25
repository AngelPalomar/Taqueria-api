using System.ComponentModel.DataAnnotations;

namespace Taqueria.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }
    }
}
