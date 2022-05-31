namespace recipe_service.Models;

public interface IUserManager
{
    UserModel? Authenticate(string? userName, string? passWord);
    string? GenerateToken(UserModel? user);
    UserStatus AddUser(UserModel userDetails);
}