using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Exam_Portal.Utils.Helpers
{
    public static class JwtHelper
    {
        public static SymmetricSecurityKey GetSigningKey(string secret)
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    }
}
