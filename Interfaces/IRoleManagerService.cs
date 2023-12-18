namespace identity_asp_net_core.Interfaces;

public interface IRoleManagerService
{
    public void CreateRoleAsync();
    public void UpdateRoleAsync();
    public void DeleteRoleAsync();
    public void GetRoleAsync();
    public void GetAllRoles();
}