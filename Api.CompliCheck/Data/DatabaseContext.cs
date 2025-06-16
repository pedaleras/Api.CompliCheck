using Api.CompliCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.CompliCheck.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Norma> Normas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabela Empresa
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("ACC_Empresas");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.Cnpj)
                      .IsRequired()
                      .HasMaxLength(18); // formato XX.XXX.XXX/XXXX-XX
                entity.Property(e => e.Setor)
                      .HasMaxLength(100);
                entity.HasMany(e => e.Normas)
                      .WithOne(n => n.Empresa)
                      .HasForeignKey(n => n.EmpresaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Tabela Norma
            modelBuilder.Entity<Norma>(entity =>
            {
                entity.ToTable("ACC_Normas");

                entity.HasKey(n => n.Id);
                entity.Property(n => n.Descricao)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(n => n.Categoria)
                      .HasMaxLength(100);
                entity.Property(n => n.DataLimite)
                      .IsRequired();
                entity.HasOne(n => n.Empresa)
                      .WithMany(e => e.Normas)
                      .HasForeignKey(n => n.EmpresaId);
            });
        }

    }

}
