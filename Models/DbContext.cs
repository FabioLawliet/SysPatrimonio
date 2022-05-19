using Microsoft.EntityFrameworkCore;

namespace SysPatrimonio.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }

        public DbSet<DbUsuario> usuarios { get; set; }
        public DbSet<DbCategoria> categoria { get; set; }
        public DbSet<DbFornecedor> fornecedor { get; set; }
        public DbSet<DbPatrimonio> patrimonio { get; set; }
        public DbSet<DbDepartamento> departamento { get; set; }
        public DbSet<DbLocal> local { get; set; }

    }
}
