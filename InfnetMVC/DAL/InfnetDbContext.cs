using InfnetMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfnetMVC.DAL
{
    public class InfnetDbContext : IdentityDbContext
    {
        public InfnetDbContext(DbContextOptions<InfnetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>()
                .HasMany(d => d.Funcionarios)
                .WithOne(f => f.Departamento)
                .HasForeignKey(f => f.DepartamentoId);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Departamento)
                .WithMany(d => d.Funcionarios)
                .HasForeignKey(f => f.DepartamentoId);
        }
    }
}
