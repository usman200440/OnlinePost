using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ONLINE_POST.Models.extras;

namespace ONLINE_POST.Models
{
    public partial class post_management_systemContext : DbContext
    {
        public post_management_systemContext()
        {
        }

        public post_management_systemContext(DbContextOptions<post_management_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeInformation> EmployeeInformations { get; set; } = null!;
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<branch> branches { get; set; } = null!;
        public virtual DbSet<City> cities { get; set; } = null!;
        public virtual DbSet<emplog> emplogs { get; set; } = null!;
        public virtual DbSet<payment> payments { get; set; } = null!;
        public virtual DbSet<servicetype> servicetypes { get; set; } = null!;
        public virtual DbSet<status> Statuses { get; set; } = null!;
        public virtual DbSet<Deliverable> Deliverables { get; set; } = null!;
        public virtual DbSet<delivery_history> Delivery_Histories { get; set; } = null!;
        public virtual DbSet<charge> Charges { get; set; } = null!;
        public virtual DbSet<package> Packages { get; set; } = null!;
        public virtual DbSet<customer_package> Customer_Packages { get; set; } = null!;
        public virtual DbSet<contact> Contacts { get; set; } = null!;
        public virtual DbSet<form> Forms { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlServer("server=DESKTOP-8VT6ODH;database=Online_Post;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInformation>(entity =>
            {
                entity.HasKey(e => e.EId)
                    .HasName("PK__employee__3E2ED64A7C1E550E");

                entity.ToTable("employee_informations");

                entity.HasIndex(e => e.EEmail, "UQ__employee__12E5DDF5AACC7E40")
                    .IsUnique();

                entity.HasIndex(e => e.EUserName, "UQ__employee__EA4040794CADA275")
                    .IsUnique();

                entity.Property(e => e.EId).HasColumnName("e_id");

                entity.Property(e => e.EEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_email");

                entity.Property(e => e.EPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_password");

                entity.Property(e => e.ERoleId)
                    .HasColumnName("e_role_id")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.EUserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_user_name");

                entity.HasOne(d => d.ERole)
                    .WithMany(p => p.EmployeeInformations)
                    .HasForeignKey(d => d.ERoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__employee___e_rol__3B75D760");
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__personal__82E06B91B4ACF851");

                entity.ToTable("personal_informations");

                entity.HasIndex(e => e.PUserName, "UQ__personal__05B441C35D5C8B1F")
                    .IsUnique();

                entity.HasIndex(e => e.PEmail, "UQ__personal__37393E4664DDC0F2")
                    .IsUnique();

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.PEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("p_email");

                entity.Property(e => e.PPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("p_password");

                entity.Property(e => e.PRoleId)
                    .HasColumnName("p_role_id")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.PUserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("p_user_name");

                entity.HasOne(d => d.PRole)
                    .WithMany(p => p.PersonalInformations)
                    .HasForeignKey(d => d.PRoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__personal___p_rol__412EB0B6");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__roles__C476232731402581");

                entity.ToTable("roles");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.RName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("r_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
