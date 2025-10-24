using Exam_Portal.Application.DTOs.Auth;
using Exam_Portal.Application.Interfaces;
using Exam_Portal.Core.Entities;
using Exam_Portal.Core.Enums;
using Exam_Portal.Core.ValueObjects;
using Exam_Portal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Portal.Infrastructure.Services
{
    public class InfrastructureAuthService : IAuthInfrastructureService
    {
        private readonly ExamPortalDbContext _context;
        private readonly PasswordHasherService _passwordHasher;

        public InfrastructureAuthService(ExamPortalDbContext context, PasswordHasherService passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> RegisterAsync(string email, string password, string name)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists");
            }

            var user = new User
            {
                Email = new Email(email),
                FullName = name,
                PasswordHash = _passwordHasher.HashPassword(password),
                Role = UserRole.Student,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, password))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            return user;
        }

        public async Task<User?> AuthenticateAsync(string email, string password, PasswordHasherService hasher)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
            if (user == null) return null;

            if (!hasher.VerifyPassword(user.PasswordHash, password)) return null;

            return user;
        }
    }
}
