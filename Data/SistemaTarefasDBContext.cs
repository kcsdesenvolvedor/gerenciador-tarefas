using Gerenciador_de_tarefas.Data.Mapping;
using Gerenciador_de_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_tarefas.Data
{
    public class SistemaTarefasDBContext: DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            :base(options)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new TarefaMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
