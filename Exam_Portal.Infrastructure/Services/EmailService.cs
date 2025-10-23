using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Infrastructure.Services
{
    public class EmailService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}: {subject}");
            return Task.CompletedTask;
        }
    }
}
