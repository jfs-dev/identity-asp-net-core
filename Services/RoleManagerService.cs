using Microsoft.AspNetCore.Identity;

using identity_asp_net_core.Interfaces;

namespace identity_asp_net_core.Services;

public class RoleManagerService(RoleManager<IdentityRole> roleManager) : IRoleManagerService
{
    private RoleManager<IdentityRole> RoleManager { get; set; } = roleManager;

    public async void CreateRoleAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Create Role");
        Console.WriteLine("-----------");

        var createRoleAdmin = new IdentityRole("Admin");
        var createRoleHero = new IdentityRole("Hero");
        var createRoleUncle = new IdentityRole("Uncle");
        var createRoleGirlfriend = new IdentityRole("Girlfriend");

        var createdRoleAdmin = await RoleManager.CreateAsync(createRoleAdmin);
        var createdRoleHero = await RoleManager.CreateAsync(createRoleHero);
        var createdRoleUncle = await RoleManager.CreateAsync(createRoleUncle);
        var createdRoleGirlfriend = await RoleManager.CreateAsync(createRoleGirlfriend);

        Console.ForegroundColor = ConsoleColor.Magenta;
        
        if (createdRoleAdmin.Succeeded)
            Console.WriteLine($"Role created - { createRoleAdmin.Id } - { createRoleAdmin.Name }");
        
        if (createdRoleHero.Succeeded)
            Console.WriteLine($"Role created - { createRoleHero.Id } - { createRoleHero.Name }");
        
        if (createdRoleUncle.Succeeded)
            Console.WriteLine($"Role created - { createRoleUncle.Id } - { createRoleUncle.Name }");
        
        if (createdRoleGirlfriend.Succeeded)
            Console.WriteLine($"Role created - { createRoleGirlfriend.Id } - { createRoleGirlfriend.Name }");
        
        Console.WriteLine("");
    }

    public async void UpdateRoleAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Update Role");
        Console.WriteLine("-----------");

        var updateRoleAdmin = await RoleManager.FindByNameAsync("Admin");
        if (updateRoleAdmin is not null)
        {
            updateRoleAdmin.Name = "Administrator";

            var updatedRoleAdmin = await RoleManager.UpdateAsync(updateRoleAdmin);

            Console.ForegroundColor = ConsoleColor.Magenta;

            if (updatedRoleAdmin.Succeeded)
                Console.WriteLine($"Role updated - { updateRoleAdmin.Id } - { updateRoleAdmin.Name }");
        }

        Console.WriteLine("");
    }

    public async void DeleteRoleAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Delete Role");
        Console.WriteLine("-----------");

        var deleteRoleUncle = await RoleManager.FindByNameAsync("Uncle");
        if (deleteRoleUncle is not null)
        {
            var deletedRoleUncle = await RoleManager.DeleteAsync(deleteRoleUncle);

            Console.ForegroundColor = ConsoleColor.Magenta;

            if (deletedRoleUncle.Succeeded)
                Console.WriteLine($"Role deleted - { deleteRoleUncle.Id } - { deleteRoleUncle.Name }");
        }

        Console.WriteLine("");
    }

    public async void GetRoleAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Get Role");
        Console.WriteLine("--------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        var returnedRole = await RoleManager.FindByNameAsync("Hero");
        if (returnedRole is not null)
            Console.WriteLine($"Returned role - { returnedRole.Id } - { returnedRole.Name }");

        Console.WriteLine("");
    }

    public void GetAllRoles()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Get All Roles");
        Console.WriteLine("-------------");
        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var currentRole in RoleManager.Roles.ToList())
        {
            Console.WriteLine($"Returned role - { currentRole.Id } - { currentRole.Name }");
        }

        Console.WriteLine("");
   }
}