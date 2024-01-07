namespace Backend.Models;

public sealed class LocalizedEmotionInfoDto
{
    public Guid Id { get; set; }

    public string Lcid { get; set; }

    public string LocalizedName { get; set; }

    public string LocalizedDesciption { get; set; }
}

