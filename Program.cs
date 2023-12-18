using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using identity_asp_net_core.Data;
using identity_asp_net_core.Services;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("identity-asp-net-core"));

services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var serviceProvider = services.BuildServiceProvider();

var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

// Usado no ambiente Web para autenticação dos usuários, é profundamente integrado ao ASP.NET Core e ao pipeline HTTP
var signInManager = serviceProvider.GetRequiredService<SignInManager<IdentityUser>>();

var userManagerService = new UserManagerService(userManager);

userManagerService.CreateUserAsync();
userManagerService.UpdateUserAsync();
userManagerService.DeleteUserAsync();
userManagerService.GetUserAsync();
userManagerService.GetAllUsers();

var roleManagerService = new RoleManagerService(roleManager);

roleManagerService.CreateRoleAsync();
roleManagerService.UpdateRoleAsync();
roleManagerService.DeleteRoleAsync();
roleManagerService.GetRoleAsync();
roleManagerService.GetAllRoles();

userManagerService.AddUserToRoleAsync();
userManagerService.GetUsersInRoleAsync();

// Usado no ambiente Web para autenticação dos usuários, é profundamente integrado ao ASP.NET Core e ao pipeline HTTP
var signInManagerService = new SignInManagerService(signInManager, userManager);

signInManagerService.SignIn();
signInManagerService.SignOut();