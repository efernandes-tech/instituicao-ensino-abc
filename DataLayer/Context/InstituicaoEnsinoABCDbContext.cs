using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataLayer.Models;
using DataLayer.Mappings;
using DataLayer.Extensions;

#nullable disable

namespace DataLayer.Context
{
    public partial class InstituicaoEnsinoABCDbContext : DbContext
    {
        public InstituicaoEnsinoABCDbContext()
        {
        }

        public InstituicaoEnsinoABCDbContext(DbContextOptions<InstituicaoEnsinoABCDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<Pagamento> Pagamentos { get; set; }
        public virtual DbSet<Parcela> Parcelas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyGlobalConfigurations();

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("aluno");

                entity.HasIndex(e => e.Cpf, "CPF_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.EnderecoCompleto).HasMaxLength(255);

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("contrato");

                entity.HasIndex(e => e.IdAluno, "fk_contrato_aluno1_idx");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.Descricao).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.Property(e => e.ValorPago).HasPrecision(10, 2);

                entity.Property(e => e.ValorTotal).HasPrecision(10, 2);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_contrato_aluno1");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.ToTable("pagamento");

                entity.HasIndex(e => e.IdAluno, "fk_pagamento_aluno1_idx");

                entity.HasIndex(e => e.IdParcela, "fk_pagamento_parcela1_idx");

                entity.Property(e => e.DataPagamento).HasColumnType("date");

                entity.Property(e => e.FormaPagamento).HasMaxLength(45);

                entity.Property(e => e.ValorPago).HasPrecision(10, 2);

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Pagamentos)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pagamento_aluno1");

                entity.HasOne(d => d.IdParcelaNavigation)
                    .WithMany(p => p.Pagamentos)
                    .HasForeignKey(d => d.IdParcela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pagamento_parcela1");
            });

            modelBuilder.Entity<Parcela>(entity =>
            {
                entity.ToTable("parcela");

                entity.HasIndex(e => e.IdContrato, "fk_parcela_contrato1_idx");

                entity.Property(e => e.DataVencimento).HasColumnType("date");

                entity.Property(e => e.NumeroParcela).HasMaxLength(45);

                entity.Property(e => e.ValorParcela).HasPrecision(10, 2);

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.ParcelasNavigation)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_parcela_contrato1");

                entity.Navigation(e => e.IdContratoNavigation).AutoInclude();
                entity.Navigation(e => e.Pagamentos).AutoInclude();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
