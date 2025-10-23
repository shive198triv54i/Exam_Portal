using Exam_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Infrastructure.Data
{
    public class ExamPortalDbContext : DbContext
    {
        public ExamPortalDbContext(DbContextOptions<ExamPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamPortalDbContext).Assembly);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Email, e =>
                {
                    e.Property(p => p.Value)
                     .HasColumnName("Email")
                     .IsRequired()
                     .HasMaxLength(100);
                });
        }
    }
}
