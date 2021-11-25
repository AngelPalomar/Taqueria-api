using Microsoft.EntityFrameworkCore;
using Taqueria.Models;

namespace Taqueria.Context
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options) {}

        public DbSet<Orden> Orden { get; set; }
        public DbSet<Platillo> Platillo { get; set; }
        public DbSet<PlatilloOrden> PlatilloOrden { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
