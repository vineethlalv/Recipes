namespace recipe_service.Models;

public interface IDataAccess
{
    bool IsUserExists(string? userName);
    void AddUser(UserModel user);
}