using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapp.Models;

public partial class SurveyWebAppContext : DbContext
{
    public SurveyWebAppContext()
    {
    }

    public SurveyWebAppContext(DbContextOptions<SurveyWebAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    public virtual DbSet<Userdata> Userdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CC99731C84");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.URole)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("u_role");
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.HasKey(e => e.SuggestionId).HasName("PK__suggesti__24FB5138D7E836FA");

            entity.ToTable("suggestion");

            entity.Property(e => e.SuggestionId).HasColumnName("suggestion_id");
            entity.Property(e => e.Suggestions)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("suggestions");
        });

        modelBuilder.Entity<Userdata>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__userdata__B51D3DEA48456995");

            entity.ToTable("userdata");

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.UEmail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("u_email");
            entity.Property(e => e.UName)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("u_name");
            entity.Property(e => e.Userrole).HasColumnName("userrole");
            entity.Property(e => e.Usersuggestion).HasColumnName("usersuggestion");

            entity.HasOne(d => d.UserroleNavigation).WithMany(p => p.Userdata)
                .HasForeignKey(d => d.Userrole)
                .HasConstraintName("FK__userdata__userro__4D94879B");

            entity.HasOne(d => d.UsersuggestionNavigation).WithMany(p => p.Userdata)
                .HasForeignKey(d => d.Usersuggestion)
                .HasConstraintName("FK__userdata__usersu__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
