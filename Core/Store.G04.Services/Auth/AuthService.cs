using Microsoft.AspNetCore.Identity;
using Store.G04.Domain.Entities.Identity;
using Store.G04.Domain.Exceptions;
using Store.G04.Domain.Exceptions.BadRequest;
using Store.G04.Domain.Exceptions.UnAuthorized;
using Store.G04.Services.Abstractions.Auth;
using Store.G04.Shared.Dtos.Auth;

namespace Store.G04.Services.Auth
{
    public class AuthService(UserManager<AppUser> _userManager) : IAuthService
    {
        public async Task<UserResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) throw new UserNotFoundException(request.Email);
            var flag = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!flag) throw new UnAuthorizedException();
            return new UserResponse
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "TODO"
            };
        }

        public async Task<UserResponse?> RegisterAsync(RegisterRequest request)
        {
            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                DisplayName = request.DisplayName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new RegistrationBadRequestException(result.Errors.Select(E => E.Description).ToList());
            return new UserResponse
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "TODO"
            };
        }
    }
}