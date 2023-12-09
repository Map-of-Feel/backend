using Database.Data;

using Microsoft.AspNetCore.Authorization;

namespace Backend;

public static class AppPolicy
{
    public const string AdminsOnly = "AdminsOnly";
    public const string HeadEditorsOnly = "HeadEditorsOnly";
    public const string EditorsOnly = "EditorsOnly";

    public static void AddPolicies(this AuthorizationOptions options)
    {
        options.AddPolicy(AdminsOnly, b => b.RequireRole(Role.Admin));
        options.AddPolicy(HeadEditorsOnly, b => b.RequireRole(Role.HeadEditor, Role.Admin));
        options.AddPolicy(EditorsOnly, b => b.RequireRole(Role.Editor, Role.HeadEditor, Role.Admin));
    }
}
