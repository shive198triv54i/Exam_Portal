using Exam_Portal.Core.Entities;
using Exam_Portal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Infrastructure.Services
{
    public class InfrastructureAuthService
    {
        private readonly ExamPortalDbContext _context;

        public InfrastructureAuthService(ExamPortalDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string email, string password, PasswordHasherService hasher)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            if (!hasher.VerifyPassword(user.PasswordHash, password)) return null;

            return user;
        }
    }
}
