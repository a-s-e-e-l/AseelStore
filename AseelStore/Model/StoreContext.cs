using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AseelStore.Model
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-EG5VIK2;Database=Store;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.CreateDataUtc)
                    .HasColumnName("CreateDataUTC")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDataUtc)
                    .HasColumnName("UpdateDataUTC")
                    .HasDefaultValueSql("(sysutcdatetime())");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.CreateDataUtc)
                    .HasColumnName("CreateDataUTC")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.Property(e => e.UpdateDataUtc)
                    .HasColumnName("UpdateDataUTC")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__items__SId__36B12243");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategory");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.CreateDataUtc)
                    .HasColumnName("CreateDataUTC")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDataUtc)
                    .HasColumnName("UpdateDataUTC")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__subcategory__CId__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
