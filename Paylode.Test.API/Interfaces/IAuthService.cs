using Paylode.Test.API.ViewModel;

namespace Paylode.Test.API.Interfaces;

public interface IAuthService
{
    AuthViewModel AuthLogin(string email);
}