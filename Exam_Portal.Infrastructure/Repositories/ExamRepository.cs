using Exam_Portal.Core.Entities;
using Exam_Portal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Infrastructure.Repositories
{
    public class ExamRepository : RepositoryBase<Exam>
    {
        public ExamRepository(ExamPortalDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Exam>> GetOpenExamsAsync()
        {
            return await _context.Exams
                .Include(e => e.Questions)
                .Where(e => e.Status == Core.Enums.ExamStatus.Open)
                .ToListAsync();
        }
    }
}
