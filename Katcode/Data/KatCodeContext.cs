using System;
using Katcode.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Katcode.Data
{
    public partial class KatCodeContext : DbContext
    {
        public KatCodeContext(DbContextOptions options) : base(options)
        {
        }

        protected KatCodeContext()
        {
        }

        public DbSet<Logs> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogsId);

                entity.Property(e => e.LogsId).HasColumnName("LogsID");

                entity.Property(e => e.Title).HasColumnName("Title")
                    .IsRequired()
                    .HasMaxLength(2550);

                entity.Property(e => e.Body).HasColumnName("Body")
                    .IsRequired()
                    .HasMaxLength(2550);

                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}