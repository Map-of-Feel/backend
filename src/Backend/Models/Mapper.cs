using Database.Models;

using Riok.Mapperly.Abstractions;

namespace Backend.Models;

[Mapper]
public static partial class Mapper
{
    #region Emotion <-> EmotionDto
    [MapperIgnoreSource(nameof(Emotion.IsDeleted))]
    public static partial EmotionDto Map(this Emotion emotion);

    [MapperIgnoreTarget(nameof(Emotion.IsDeleted))]
    public static partial Emotion Map(this EmotionDto emotionDto);

    public static partial IEnumerable<EmotionDto> Map(this IEnumerable<Emotion> emotions);

    public static partial IEnumerable<Emotion> Map(this IEnumerable<EmotionDto> emotions);
    #endregion

    #region AppRole <-> AppRoleDto
    [MapperIgnoreSource(nameof(AppRole.NormalizedName))]
    [MapperIgnoreSource(nameof(AppRole.ConcurrencyStamp))]
    public static partial AppRoleDto Map(this AppRole role);
    [MapperIgnoreTarget(nameof(AppRole.NormalizedName))]
    [MapperIgnoreTarget(nameof(AppRole.ConcurrencyStamp))]
    public static partial AppRole Map(this AppRoleDto roleDto);
    public static partial IEnumerable<AppRoleDto> Map(this IEnumerable<AppRole> emotions);
    public static partial IEnumerable<AppRole> Map(this IEnumerable<AppRoleDto> emotions);
    #endregion

    #region AppUser <-> UserDto
    [MapperIgnoreSource(nameof(AppUser.NormalizedEmail))]
    [MapperIgnoreSource(nameof(AppUser.NormalizedUserName))]
    [MapperIgnoreSource(nameof(AppUser.Email))]
    [MapperIgnoreSource(nameof(AppUser.PhoneNumber))]
    [MapperIgnoreSource(nameof(AppUser.ConcurrencyStamp))]
    [MapperIgnoreSource(nameof(AppUser.SecurityStamp))]
    [MapperIgnoreSource(nameof(AppUser.PasswordHash))]
    [MapperIgnoreSource(nameof(AppUser.PhoneNumberConfirmed))]
    [MapperIgnoreSource(nameof(AppUser.TwoFactorEnabled))]
    [MapperIgnoreSource(nameof(AppUser.LockoutEnabled))]
    [MapperIgnoreSource(nameof(AppUser.LockoutEnd))]
    [MapperIgnoreSource(nameof(AppUser.AccessFailedCount))]
    [MapperIgnoreSource(nameof(AppUser.EmailConfirmed))]
    public static partial AppUserDto Map(this AppUser role);
    [MapperIgnoreTarget(nameof(AppUser.NormalizedEmail))]
    [MapperIgnoreTarget(nameof(AppUser.NormalizedUserName))]
    [MapperIgnoreTarget(nameof(AppUser.Email))]
    [MapperIgnoreTarget(nameof(AppUser.PhoneNumber))]
    [MapperIgnoreTarget(nameof(AppUser.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(AppUser.SecurityStamp))]
    [MapperIgnoreTarget(nameof(AppUser.PasswordHash))]
    [MapperIgnoreTarget(nameof(AppUser.PhoneNumberConfirmed))]
    [MapperIgnoreTarget(nameof(AppUser.TwoFactorEnabled))]
    [MapperIgnoreTarget(nameof(AppUser.LockoutEnabled))]
    [MapperIgnoreTarget(nameof(AppUser.LockoutEnd))]
    [MapperIgnoreTarget(nameof(AppUser.AccessFailedCount))]
    [MapperIgnoreTarget(nameof(AppUser.EmailConfirmed))]
    public static partial AppUser Map(this AppUserDto roleDto);
    public static partial IEnumerable<AppUserDto> Map(this IEnumerable<AppUser> emotions);
    public static partial IEnumerable<AppUser> Map(this IEnumerable<AppUserDto> emotions);
    #endregion

    #region 
    [MapperIgnoreSource(nameof(LocalizedEmotionInfo.Emotion))]
    [MapperIgnoreSource(nameof(LocalizedEmotionInfo.EmotionId))]
    public static partial LocalizedEmotionInfoDto Map(this LocalizedEmotionInfo info);
    [MapperIgnoreTarget(nameof(LocalizedEmotionInfo.Emotion))]
    [MapperIgnoreTarget(nameof(LocalizedEmotionInfo.EmotionId))]
    public static partial LocalizedEmotionInfo Map(this LocalizedEmotionInfoDto info);
    #endregion

    #region 
    [MapperIgnoreSource(nameof(EmotionDefaultComposePart.Emotion))]
    public static partial EmotionDefaultComposePartDto Map(this EmotionDefaultComposePart obj);
    [MapperIgnoreTarget(nameof(EmotionDefaultComposePart.Emotion))]
    public static partial EmotionDefaultComposePart Map(this EmotionDefaultComposePartDto obj);
    #endregion

    #region
    [MapperIgnoreSource(nameof(EmotionDefaultComposePart.Emotion))]
    public static partial UserDefinedCompositionDto Map(this UserDefinedComposition obj);
    [MapperIgnoreTarget(nameof(EmotionDefaultComposePart.Emotion))]
    public static partial UserDefinedComposition Map(this UserDefinedCompositionDto obj);
    #endregion
}