namespace Backend.Models;

public sealed class AppUserDto
{
    public required string Id { get; set; } = string.Empty;

    public required string UserName { get; set; } = string.Empty;
}
