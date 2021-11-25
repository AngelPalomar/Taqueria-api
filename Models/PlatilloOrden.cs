using System.ComponentModel.DataAnnotations;

namespace Taqueria.Models
{
    public class PlatilloOrden
    {
        [Key]
        public int Id { get; set; }
        public int IdPlatillo { get; set; }
        public int IdOrden { get; set; }
        public int Cantidad { get; set; }
    }
}
