using Exam_Portal.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Core.Entities
{
    public class Result : AuditableEntity
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }

        public int Score { get; set; }
        public bool IsPaid { get; set; } = false;
        public string? PaymentId { get; set; }   
        public string? PdfReceiptPath { get; set; }

        public User? User { get; set; }
        public Exam? Exam { get; set; }
    }
}
