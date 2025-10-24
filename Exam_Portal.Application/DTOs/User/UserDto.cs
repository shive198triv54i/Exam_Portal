using Exam_Portal.Core.Enums;

namespace Exam_Portal.Application.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
