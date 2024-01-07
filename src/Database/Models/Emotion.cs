using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models;

[EntityTypeConfiguration(typeof(EmotionConfiguration))]
public class Emotion
{
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// The english name of the emotion
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    public bool IsCoreEmotion { get; set; }

    public bool IsDeleted { get; set; }

    public string Color { get; set; } = string.Empty;

    public virtual ICollection<LocalizedEmotionInfo> LocalizedInfos { get; set; } = null!;

    public IList<EmotionDefaultComposePart> DefaultComposeParts { get; set; } = new List<EmotionDefaultComposePart>();

    public IList<UserDefinedComposition> UserDefinedCompositions { get; set; } = new List<UserDefinedComposition>();
}

internal sealed class EmotionConfiguration : IEntityTypeConfiguration<Emotion>
{
    public void Configure(EntityTypeBuilder<Emotion> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.LocalizedInfos)
            .WithOne(e => e.Emotion)
            .HasForeignKey(e => e.EmotionId);

        builder.Navigation(e => e.LocalizedInfos);
    }
}
