using System;
using System.Collections.Generic;
using DbConnection.db.Supercharge.Model;
using Microsoft.EntityFrameworkCore;

namespace DbConnection.db.Supercharge.Context;

public partial class SuperchargeContext : DbContextExtended
{
    public SuperchargeContext(DbContextOptions<SuperchargeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK_Booking_BookingId");

            entity.ToTable("Booking");

            entity.Property(e => e.CreatedOnUtc)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BookingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Booking_CreatedBy_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.BookingModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Booking_ModifiedBy_FK");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Room");

            entity.HasOne(d => d.Visitor).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Visitor");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK_Hotel_HotelId");

            entity.ToTable("Hotel");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(300);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.HotelCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Hotel_CreatedBy_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.HotelModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Hotel_ModifiedBy_FK");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK_Price_PriceId");

            entity.ToTable("Price");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.PriceType).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PriceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Price_CreatedBy_FK");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Prices)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Price_Hotel");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PriceModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Price_ModifiedBy_FK");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK_Room_RoomId");

            entity.ToTable("Room");

            entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.RoomNumber).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoomCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Room_CreatedBy_FK");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Hotel");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RoomModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("Room_ModifiedBy_FK");

            entity.HasOne(d => d.Price).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User_UserId");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ_User_Email").IsUnique();

            entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(300);
            entity.Property(e => e.LastName).HasMaxLength(300);
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("User_CreatedBy_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InverseModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("User_ModifiedBy_FK");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.VisitorId).HasName("PK_Visitor_VisitorId");

            entity.ToTable("Visitor");

            entity.HasIndex(e => e.Email, "UQ_Visitor_Email").IsUnique();

            entity.Property(e => e.CreatedOnUtc)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(300);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(300);
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VisitorCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Visitor_CreatedBy");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.VisitorModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_Visitor_ModifiedBy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
