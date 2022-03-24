using System;
using System.Collections.Generic;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksStore.Infraestructure.DataAccess
{
    public partial class bookDBContext : DbContext
    {
        public bookDBContext()
        {
        }

        public bookDBContext(DbContextOptions<bookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Author)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PublicationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_BookCategory");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
