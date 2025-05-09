using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SkladisteAngular.Server.Models
{
    public partial class SkladisteContext : DbContext
    {
        public SkladisteContext()
        {
        }

        public SkladisteContext(DbContextOptions<SkladisteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Deliverer> Deliverers { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemStore> ItemStores { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ELINI\\SQLEXPRESS;Database=Skladiste;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Deliverer>(entity =>
            {
                entity.ToTable("Deliverer");

                entity.Property(e => e.DelivererId).HasColumnName("deliverer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.ContactMail)
                    .HasMaxLength(50)
                    .HasColumnName("contact_mail");

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(50)
                    .HasColumnName("contact_phone");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.DelivererId).HasColumnName("deliverer_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Item_Category");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Item_Country");

                entity.HasOne(d => d.Deliverer)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.DelivererId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Item_Deliverer");
            });

            modelBuilder.Entity<ItemStore>(entity =>
            {
                entity.ToTable("ItemStore");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemStores)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ItemStore_Item");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ItemStores)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_ItemStore_Store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
