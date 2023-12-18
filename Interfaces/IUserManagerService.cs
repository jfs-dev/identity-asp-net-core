namespace identity_asp_net_core.Interfaces;

public interface IUserManagerService
{
    public void CreateUserAsync();
    public void UpdateUserAsync();
    public void DeleteUserAsync();
    public void GetUserAsync();
    public void GetAllUsers();
    public void AddUserToRoleAsync();
    public void GetUsersInRoleAsync();
}