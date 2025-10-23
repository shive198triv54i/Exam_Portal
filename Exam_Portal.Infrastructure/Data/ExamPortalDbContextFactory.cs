using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Exam_Portal.Infrastructure.Data
{
    public class ExamPortalDbContextFactory : IDesignTimeDbContextFactory<ExamPortalDbContext>
    {
        public ExamPortalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExamPortalDbContext>();
            optionsBuilder.UseSqlServer("Server=ITT-SHIVESH-TRI\\SQLEXPRESS;Database=ExamPortalDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ExamPortalDbContext(optionsBuilder.Options);
        }
    }
}
