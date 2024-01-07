using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models;

[EntityTypeConfiguration(typeof(EmotionDefaultComposePartConfiguration))]
public class EmotionDefaultComposePart
{
    public Guid Id { get; set; }

    public Emotion Emotion { get; set; } = null!;

    public Emotion PartEmotion { get; set; } = null!;

    public decimal PartValue { get; set; }
}

internal sealed class EmotionDefaultComposePartConfiguration : IEntityTypeConfiguration<EmotionDefaultComposePart>
{
    public void Configure(EntityTypeBuilder<EmotionDefaultComposePart> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Emotion)
            .WithMany(e => e.DefaultComposeParts);

        builder.HasOne(e => e.PartEmotion);
    }
}
