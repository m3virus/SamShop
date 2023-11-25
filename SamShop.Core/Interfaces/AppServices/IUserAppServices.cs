using Microsoft.AspNetCore.Identity;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface IUserAppServices
    {
        Task <IdentityResult> Register (AppUser appUser, string password ,string appRole , CancellationToken cancellation);
        Task<SignInResult> SignIn(string Email, string password , CancellationToken cancellation);
        Task SignOut();
    }
}
