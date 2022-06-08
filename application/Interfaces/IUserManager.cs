using recipe_service.Application.Constants;
using recipe_service.Application.DTOs;

namespace recipe_service.Application.Interfaces;

public interface IUserManager
{
    UserModel? Authenticate(string? userName, string? passWord);
    string? GenerateToken(UserModel? user);
    UserStatus AddUser(UserModel userDetails);
}