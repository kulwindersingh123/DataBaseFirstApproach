using Assignment22.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Assignment22
{
    public class CompanyContext:DbContext
    {
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        public virtual DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=LAPTOP-HOHQ552T\SQLEXPRESS;Database=EmployeeManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Department>(entity =>
        {
        entity.Property(e => e.Id)
        .IsRequired()
        .HasMaxLength(30);
        entity.HasKey(e => e.Id);


        });

        modelBuilder.Entity<Employee>(entity =>
        {
        entity.Property(d => d.Id)
        .IsRequired();
        *//*entity.HasOne(e => e.Department)
        .WithMany(g => g.skill)
        .HasForeignKey<Employee>();*//*

        });
        modelBuilder.Entity<EmployeeSkill>(entity =>
        {
        entity.Property(d => d.Id)
        .HasColumnName("EmployeeSkill_Id")
        .IsRequired()
        .IsUnicode(false);
        entity.Property(d => d.EmployeeId)
        .IsRequired()
        .IsUnicode(false);
        entity.HasKey(d=>d.Id)  
           }
       }
               });

        }
       */

    }
}
