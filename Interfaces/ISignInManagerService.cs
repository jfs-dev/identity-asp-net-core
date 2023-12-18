namespace identity_asp_net_core.Interfaces;

public interface ISignInManagerService
{
    public void SignIn();
    public void SignOut();    
}