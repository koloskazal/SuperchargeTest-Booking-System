using DbConnection.db.Supercharge.Model;
using Microsoft.EntityFrameworkCore;

namespace DbConnection.db.Supercharge.Context;

public partial class SuperchargeContext : DbContextExtended
{
    public SuperchargeContext(DbContextOptions<SuperchargeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestTable> TestTables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>(entity =>
        {
            entity.HasKey(e => e.TestTableId).HasName("PK_TestTable_TestTableId");

            entity.ToTable("TestTable");

            entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.FirstData).HasMaxLength(300);
            entity.Property(e => e.ModifiedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.SecondData).HasMaxLength(300);
            entity.Property(e => e.ThirdData)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TestTableCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("TestTable_CreatedBy_FK");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.TestTableModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("TestTable_ModifiedBy_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User_UserId");

            entity.ToTable("User");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
