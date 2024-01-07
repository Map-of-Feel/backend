using Database.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database.Data;

public sealed class MapOfFeelContext : IdentityDbContext<AppUser, AppRole, string>
{
    private const string AdminRoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210";
    private const string HeadEditorRoleId = "e738ea63-6593-4098-b0b5-a42c84bfdc66";
    private const string EditorRoleId = "0794c54b-7b02-415d-a267-6a9c21b39bd3";

    private const string AdminUserId = "153dbfe4-1b83-49ce-b7f7-41612d94a150";

    public DbSet<Emotion> Emotions { get; set; }

    public MapOfFeelContext(DbContextOptions<MapOfFeelContext> options)
       : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seeding a  'Administrator' role to AspNetRoles table
        modelBuilder.Entity<AppRole>()
            .HasData(
                new AppRole
                {
                    Id = AdminRoleId,
                    Name = Role.Admin,
                    NormalizedName = Role.Admin.ToUpperInvariant(),
                },
                new AppRole
                {
                    Id = HeadEditorRoleId,
                    Name = Role.HeadEditor,
                    NormalizedName = Role.HeadEditor.ToUpperInvariant(),
                },
                new AppRole
                {
                    Id = EditorRoleId,
                    Name = Role.Editor,
                    NormalizedName = Role.Editor.ToUpperInvariant(),
                });

        //Seeding the User to AspNetUsers table
        const string userName = "timo_weike@gmx.de";
        var userNameNormalized = userName.ToUpperInvariant();
        const string passwordHash = "AQAAAAIAAYagAAAAEBHi9XJZFbM7BHe5DenM+akwUKWspGnBUx+TJFXOQvVJ1iTNuNMQWyaOQfb3VIejdQ==";
        modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = AdminUserId, // primary key
                UserName = userName,
                NormalizedUserName = userNameNormalized,
                Email = userName,
                NormalizedEmail = userNameNormalized,
                EmailConfirmed = true,
                PasswordHash = passwordHash,
            }
        );


        //Seeding the relation between our user and role to AspNetUserRoles table
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = AdminUserId,
            }
        );
    }
}
