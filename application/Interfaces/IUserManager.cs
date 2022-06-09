using recipe_service.Application.Constants;
using recipe_service.Application.DTOs;

namespace recipe_service.Application.Interfaces;

public interface IUserManager
{
    string? Authenticate(string? userName, string? passWord);
    UserStatus AddUser(UserModel userDetails);
}