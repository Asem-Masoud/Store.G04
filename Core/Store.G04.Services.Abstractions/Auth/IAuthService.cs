using Store.G04.Shared.Dtos.Auth;

namespace Store.G04.Services.Abstractions.Auth
{
    public interface IAuthService
    {
        Task<UserResponse?> LoginAsync(LoginRequest request);
        Task<UserResponse?> RegisterAsync(RegisterRequest request);
    }
}
