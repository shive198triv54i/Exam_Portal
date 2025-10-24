using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string email)
            => !string.IsNullOrWhiteSpace(email) && email.Contains("@");
    }
}
