using Microsoft.AspNetCore.Identity;

using identity_asp_net_core.Interfaces;

namespace identity_asp_net_core.Services;

public class SignInManagerService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : ISignInManagerService
{
    private SignInManager<IdentityUser> SignInManager { get; set; } = signInManager;
    private UserManager<IdentityUser> UserManager { get; set; } = userManager;

    public async void SignIn()
    {
        if (Environment.UserInteractive) return;
    
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sign In");
        Console.WriteLine("-------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        var returnedUserFindByName = await UserManager.FindByNameAsync("Peter.Parker");
        if (returnedUserFindByName is not null)
        {
            var passwordSignIn = await SignInManager.PasswordSignInAsync(returnedUserFindByName, "Password@Peter2023", false, false);

            if (passwordSignIn.Succeeded)
                Console.WriteLine("Usuário autenticado.");
        }
    
        Console.WriteLine("");
    }

    public async void SignOut()
    {
        if (Environment.UserInteractive) return;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sign Out");
        Console.WriteLine("--------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        await SignInManager.SignOutAsync();

        Console.WriteLine("Usuário desconectado.");
    }
}