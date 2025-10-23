using Exam_Portal.Core.Common;
using Exam_Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Core.Entities
{
    public class Exam : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExamDate { get; set; }
        public decimal Fee { get; set; }
        public ExamStatus Status { get; set; } = ExamStatus.Open;

        public ICollection<Question>? Questions { get; set; }
        public ICollection<Result>? Results { get; set; }
    }
}
