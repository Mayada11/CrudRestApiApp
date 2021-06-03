using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudRestApiApp.Models
{
    public partial class SD_CompanyContext : DbContext
    {
        public SD_CompanyContext()
        {
        }

        public SD_CompanyContext(DbContextOptions<SD_CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<WorksOn> WorksOn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=SD_Company;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo);

                entity.Property(e => e.DeptNo).ValueGeneratedNever();

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectNo);

                entity.Property(e => e.Budget).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorksOn>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.ProjectNo });

                entity.ToTable("Works_on");

                entity.Property(e => e.EnterDate)
                    .HasColumnName("Enter_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Job).HasMaxLength(50);

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.WorksOn)
                    .HasForeignKey(d => d.EmpNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Works_on_Employee");

                entity.HasOne(d => d.ProjectNoNavigation)
                    .WithMany(p => p.WorksOn)
                    .HasForeignKey(d => d.ProjectNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Works_on_Project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
