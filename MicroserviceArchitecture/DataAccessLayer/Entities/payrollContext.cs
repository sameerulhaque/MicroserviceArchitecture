using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Entities
{
    public partial class payrollContext : DbContext
    {
        public payrollContext()
        {
        }

        public payrollContext(DbContextOptions<payrollContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; } = null!;
        public virtual DbSet<Employe> Employes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SAMEERULHAQ-LAP\\MSSQLSERVER1;Database=payroll;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.RecId).ValueGeneratedNever();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<DepartmentEmployee>(entity =>
            {
                entity.Property(e => e.RecId).ValueGeneratedNever();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.DepartmentRec)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.DepartmentRecId)
                    .HasConstraintName("Department_FK1");

                entity.HasOne(d => d.EmployeRec)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.EmployeRecId)
                    .HasConstraintName("Employe_FK1");
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.Property(e => e.RecId).ValueGeneratedNever();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
