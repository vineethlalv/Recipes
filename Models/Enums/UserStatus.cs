namespace recipe_service.Models;

public enum UserStatus
{
    Ok,
    InvalidInputs,
    UserNameExists,
    PWPolicyViolation
}