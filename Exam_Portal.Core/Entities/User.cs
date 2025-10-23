using Exam_Portal.Core.Common;
using Exam_Portal.Core.Enums;
using Exam_Portal.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Core.Entities
{
    public class User : AuditableEntity
    {
        public string FullName { get; set; } = string.Empty;
        public Email Email { get; set; } = default!;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Student;

        public ICollection<Result>? Results { get; set; }
    }
}
