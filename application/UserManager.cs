
using Microsoft.Extensions.Configuration;

using recipe_service.Application.Constants;
using recipe_service.Application.Interfaces;
using recipe_service.Application.DTOs;


namespace recipe_service.Application;

public class UserManager : IUserManager
{
    private IConfiguration _configuration;
    private IDataAccess _dataAccess;
    private TokenManager _tokenMan;

    public UserManager(IConfiguration configuration, IDataAccess dataAccess)
    {
        _configuration = configuration;
        _dataAccess = dataAccess;
        _tokenMan = new TokenManager(_configuration);
    }

    /// <summary>
    /// Authenticate Users and returns JWT token
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passWord"></param>
    /// <returns>JWT token when authenticated, null otherwise</returns>
    public string? Authenticate(string? userName, string? passWord)
    {
        // @TODO: slat password compare against db
        UserModel? user = null;
        string? token = null;

        // @TEMP code
        user = new UserModel{ UserName = "user123" };
        //////////////////////////////////////////////
        if(user != null)
        {
            token = _tokenMan.GenerateToken(user);
        }
        return token;
    }

    public UserStatus AddUser(UserModel userDetails)
    {
        if(userDetails.UserName is null || userDetails.PassWord is null)
            return UserStatus.InvalidInputs;

        if(_dataAccess.IsUserExists(userDetails.UserName))
            return UserStatus.UserNameExists;
        // @TODO: check password match policy
        else
        {
            _dataAccess.AddUser(userDetails);
            return UserStatus.Ok;
        }
    }
}