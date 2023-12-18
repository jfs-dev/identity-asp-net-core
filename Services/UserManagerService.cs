using Microsoft.AspNetCore.Identity;

using identity_asp_net_core.Interfaces;

namespace identity_asp_net_core.Services;

public class UserManagerService(UserManager<IdentityUser> userManager) : IUserManagerService
{
    private UserManager<IdentityUser> UserManager { get; set; } = userManager;

    public async void CreateUserAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Create User");
        Console.WriteLine("-----------");

        var createUserPeterParker = new IdentityUser("Peter.Parker") {  Email = "peter.parker@marvel.com" };
        var createUserBenParker = new IdentityUser("Ben.Parker") { Email = "ben.parker@marvel.com" };
        var createUserMaryJane = new IdentityUser("Mary.Jane") { Email = "mary.jane@marvel.com" };

        var createdUserPeterParker = await UserManager.CreateAsync(createUserPeterParker, "Password@Peter2023");
        var createdUserBenParker = await UserManager.CreateAsync(createUserBenParker, "Password@Ben2023");
        var createdUserMaryJane = await UserManager.CreateAsync(createUserMaryJane, "Password@Mary2023");

        Console.ForegroundColor = ConsoleColor.Magenta;

        if (createdUserPeterParker.Succeeded)
            Console.WriteLine($"User created - { createUserPeterParker.Id } - { createUserPeterParker.UserName } - { createUserPeterParker.Email }");

        if (createdUserBenParker.Succeeded)
            Console.WriteLine($"User created - { createUserBenParker.Id } - { createUserBenParker.UserName } - { createUserBenParker.Email }");

        if (createdUserMaryJane.Succeeded)
            Console.WriteLine($"User created - { createUserMaryJane.Id } - { createUserMaryJane.UserName } - { createUserMaryJane.Email }");

        Console.WriteLine("");
    }

    public async void UpdateUserAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Update User");
        Console.WriteLine("-----------");

        var updateUserMaryJane = await UserManager.FindByNameAsync("Mary.Jane");
        if (updateUserMaryJane is not null)
        {
            updateUserMaryJane.Email = "mary.jane.watson@marvel.com";

            var updatedUserMaryJane = await UserManager.UpdateAsync(updateUserMaryJane);

            Console.ForegroundColor = ConsoleColor.Magenta;

            if (updatedUserMaryJane.Succeeded)
                Console.WriteLine($"User updated - { updateUserMaryJane.Id } - { updateUserMaryJane.UserName } - { updateUserMaryJane.Email }");
        }

        Console.WriteLine("");
    }

    public async void DeleteUserAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Delete User");
        Console.WriteLine("-----------");

        var deleteUserBenParker = await UserManager.FindByNameAsync("Ben.Parker");
        if (deleteUserBenParker is not null)
        {
            var deletedUserBenParker = await UserManager.DeleteAsync(deleteUserBenParker);

            Console.ForegroundColor = ConsoleColor.Magenta;

            if (deletedUserBenParker.Succeeded)
                Console.WriteLine($"User deleted - { deleteUserBenParker.Id } - { deleteUserBenParker.UserName } - { deleteUserBenParker.Email }");
        }

        Console.WriteLine("");
    }

    public async void GetUserAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Get User");
        Console.WriteLine("--------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        var returnedUser = await UserManager.FindByNameAsync("Peter.Parker");
        if (returnedUser is not null)
            Console.WriteLine($"Returned user - { returnedUser.Id } - { returnedUser.UserName } - { returnedUser.Email }");

        Console.WriteLine("");
    }

    public void GetAllUsers()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Get All Users");
        Console.WriteLine("-------------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var currentUser in UserManager.Users.ToList())
        {
            Console.WriteLine($"Returned user - { currentUser.Id } - { currentUser.UserName } - { currentUser.Email }");
        }

        Console.WriteLine("");
    }

    public async void AddUserToRoleAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Add User in Role");
        Console.WriteLine("----------------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        var returnedUserPeterParker = await UserManager.FindByNameAsync("Peter.Parker");

        if (returnedUserPeterParker is not null)
        {
            var addToRole = await UserManager.AddToRoleAsync(returnedUserPeterParker, "Hero");

            if (addToRole.Succeeded)
                Console.WriteLine($"User { returnedUserPeterParker.UserName } added to 'Hero' role.");
        }

        Console.WriteLine("");
    }

    public async void GetUsersInRoleAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Get Users in Role");
        Console.WriteLine("-----------------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        var returnedUsersInRole = await UserManager.GetUsersInRoleAsync("Hero");

        foreach (var currentUserInRole in returnedUsersInRole)
        {
            Console.WriteLine($"User { currentUserInRole.UserName } in role 'Hero'.");
        }
    }
}