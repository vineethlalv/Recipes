using recipe_service.Application.DTOs;

namespace recipe_service.Application.Interfaces;

public interface IDataAccess
{
    bool IsUserExists(string? userName);
    void AddUser(UserModel user);
}