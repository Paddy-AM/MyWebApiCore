using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWebApiCore.Models
{
    public partial class WebapicoreContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }

        public WebapicoreContext(DbContextOptions<WebapicoreContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Tags).HasColumnType("xml");
            });
        }
    }
}
