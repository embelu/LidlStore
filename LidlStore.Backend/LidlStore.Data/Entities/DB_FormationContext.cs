using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LidlStore.Data.Entities
{
    public partial class DB_FormationContext : DbContext
    {
        public DB_FormationContext()
        {
        }

        public DB_FormationContext(DbContextOptions<DB_FormationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LidlCategorieLb> LidlCategorieLbs { get; set; }
        public virtual DbSet<LidlCommandeLb> LidlCommandeLbs { get; set; }
        public virtual DbSet<LidlDetailCommandeLb> LidlDetailCommandeLbs { get; set; }
        public virtual DbSet<LidlProduitLb> LidlProduitLbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=S319SQLT1\\DEVSQL319;Database=DB_Formation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LidlCategorieLb>(entity =>
            {
                entity.ToTable("Lidl_Categorie_LB");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LienImg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LidlCommandeLb>(entity =>
            {
                entity.ToTable("Lidl_Commande_LB");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Statut)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LidlDetailCommandeLb>(entity =>
            {
                entity.ToTable("Lidl_DetailCommande_LB");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.LidlDetailCommandeLbs)
                    .HasForeignKey(d => d.IdCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lidl_DetailCommande_LB_Lidl_Commande_LB");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.LidlDetailCommandeLbs)
                    .HasForeignKey(d => d.IdProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lidl_DetailCommande_LB_Lidl_Produit_LB");
            });

            modelBuilder.Entity<LidlProduitLb>(entity =>
            {
                entity.ToTable("Lidl_Produit_LB");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LienImg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prix).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.LidlProduitLbs)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lidl_Produit_LB_Lidl_Categorie_LB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
