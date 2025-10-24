using Exam_Portal.Application.DTOs.Auth;
using Exam_Portal.Core.Entities;

namespace Exam_Portal.Application.Interfaces
{
    public interface IAuthInfrastructureService
    {
        Task<User> RegisterAsync(string email, string password, string name);
        Task<User> ValidateUserAsync(string email, string password);
    }
}
