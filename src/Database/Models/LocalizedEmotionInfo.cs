using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models;

[EntityTypeConfiguration(typeof(LocalizedEmotionInfoConfiguration))]
public class LocalizedEmotionInfo
{
    [Required]
    public Guid Id { get; set; }

    public string Lcid { get; set; } = null!;

    public virtual Emotion Emotion { get; set; } = null!;

    public string LocalizedName { get; set; }

    public string LocalizedDesciption { get; set; }
}

internal sealed class LocalizedEmotionInfoConfiguration : IEntityTypeConfiguration<LocalizedEmotionInfo>
{
    public void Configure(EntityTypeBuilder<LocalizedEmotionInfo> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .HasOne(e => e.Emotion)
            .WithMany(e => e.LocalizedInfos);
    }
}