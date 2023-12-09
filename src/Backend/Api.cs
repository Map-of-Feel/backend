using Database.Models;

namespace Backend;

public static class Api
{
    public static IEndpointRouteBuilder MapApi(this IEndpointRouteBuilder builder)
    {
        var apiGroup = builder
            .MapGroup("/api")
            .WithOpenApi();

        apiGroup
            .MapGroup("/account")
            //.WithGroupName("IdentityApi")
            .MapUserManagementApi()
            .MapIdentityApi<AppUser>();

        apiGroup
            .MapGroup("/emotions")
            .MapEmotionApi();

        return builder;
    }
}
