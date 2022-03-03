using Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
 public class Context : DbContext
 {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
 => options.UseMySql("Server=localhost;User Id=root;Database=dentista");
 }
}