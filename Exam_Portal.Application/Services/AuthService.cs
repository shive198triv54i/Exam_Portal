using AutoMapper;
using Exam_Portal.Application.DTOs.Auth;
using Exam_Portal.Application.Interfaces;

namespace Exam_Portal.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthInfrastructureService _authInfrastructure;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IAuthInfrastructureService authInfrastructure, ITokenService tokenService, IMapper mapper)
        {
            _authInfrastructure = authInfrastructure;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var user = await _authInfrastructure.RegisterAsync(request.Email, request.Password, request.Name);
            var token = await _tokenService.GenerateTokenAsync(user);
            return new AuthResponseDto { Email = user.Email.Value, Token = token, Role = user.Role.ToString() };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _authInfrastructure.ValidateUserAsync(request.Email, request.Password);
            var token = await _tokenService.GenerateTokenAsync(user);
            return new AuthResponseDto { Email = user.Email.Value, Token = token, Role = user.Role.ToString() };
        }
    }
}
