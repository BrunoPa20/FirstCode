using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class MyDbContext:DbContext
    {

        public DbSet<Articulo> articulos { get; set; }
        public DbSet<Cliente> clientes { get; set; }

        public DbSet<Tipo_documento> tipo_Documentos { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options)
        {

        }

    }
}
