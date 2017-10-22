using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gerenciadorDeConfiguracao.Models
{
    public partial class GerenciadorDeConfiguracaoContext : DbContext
    {
        public virtual DbSet<Clientes> Clientes { get; set; }

        public virtual DbSet<Options> Options { get; set; }

        public GerenciadorDeConfiguracaoContext(DbContextOptions<GerenciadorDeConfiguracaoContext> options)
            : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Estudo;Integrated Security=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Endereco)
                    .IsRequired();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Temperatura)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hora)
                .IsRequired();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
