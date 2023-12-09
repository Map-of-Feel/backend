using Backend.Models;

using Database.Data;
using Database.Models;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public static class UserManagementApi
{
    public static RouteGroupBuilder MapUserManagementApi(this RouteGroupBuilder build)
    {
        var roleGroup = build
            .MapGroup("/roles")
            .RequireAuthorization(AppPolicy.AdminsOnly);

        roleGroup
            .MapGet("/", GetAllRoles);

        var userGroup = build
            .MapGroup("/users")
            .RequireAuthorization(AppPolicy.AdminsOnly);

        userGroup.MapGet("/", GetAllUsers);
        userGroup.MapPost("/role", AddRoleToUser);
        userGroup.MapDelete("/role", RemoveRoleFromUser);

        return build;
    }

    public static async Task<Ok<List<AppRoleDto>>> GetAllRoles(
        [FromServices] IRepo<AppRole> appRoles)
    {
        var roles = await appRoles.ToListAsync();

        return TypedResults.Ok(roles.Map().ToList());
    }

    public static async Task<Ok<List<AppUserDto>>> GetAllUsers(
        [FromServices] IRepo<AppUser> appUsers)
    {
        var users = await appUsers.ToListAsync();

        return TypedResults.Ok(users.Map().ToList());
    }

    public static async Task<IResult> AddRoleToUser(
        [FromBody()] UserRoleId data,
        [FromServices] UserManager<AppUser> userManager,
        [FromServices] IRoleStore<AppRole> roleStore,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(data.UserId);

        if (user == null)
        {
            return TypedResults.NotFound("User not found");
        }

        var role = await roleStore.FindByIdAsync(data.RoleId, cancellationToken);

        if (role == null)
        {
            return TypedResults.NotFound("Role not found");
        }

        var res = await userManager.AddToRoleAsync(user, role.Name!);

        if (res.Succeeded)
        {
            return TypedResults.Ok();
        }
        else
        {
            return TypedResults.Conflict(res.Errors);
        }
    }

    public static async Task<IResult> RemoveRoleFromUser(
        [FromBody()] UserRoleId data,
        [FromServices] UserManager<AppUser> userManager,
        [FromServices] IRoleStore<AppRole> roleStore,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(data.UserId);

        if (user == null)
        {
            return TypedResults.NotFound("User not found");
        }

        var role = await roleStore.FindByIdAsync(data.RoleId, cancellationToken);

        if (role == null)
        {
            return TypedResults.NotFound("Role not found");
        }

        var res = await userManager.RemoveFromRoleAsync(user, role.Name!);

        if (res.Succeeded)
        {
            return TypedResults.Ok();
        }
        else
        {
            return TypedResults.Conflict(res.Errors);
        }

    }

    public record UserRoleId(string UserId, string RoleId);
}