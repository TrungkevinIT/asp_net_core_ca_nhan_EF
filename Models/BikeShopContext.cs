using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiTapQuayVideo_EF.Models;

public partial class BikeShopContext : DbContext
{
    public BikeShopContext()
    {
    }

    public BikeShopContext(DbContextOptions<BikeShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=BikeShop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8992143E5");

            entity.Property(e => e.CustomerAddress).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HashedPassword).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.States).HasDefaultValue((byte)1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
