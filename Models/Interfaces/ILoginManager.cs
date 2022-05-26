namespace recipe_service.Models;

public interface ILoginManager
{
    UserModel? Authenticate(string? userName, string? passWord);
    string? GenerateToken(UserModel? user);
}