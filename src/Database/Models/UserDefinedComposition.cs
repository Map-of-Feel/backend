using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Models;



[EntityTypeConfiguration(typeof(UserDefinedCompositionConfiguration))]
public class UserDefinedComposition
{
    public Guid Id { get; set; }

    public Emotion Emotion { get; set; }

    public Emotion PartEmotion { get; set; }

    public decimal PartValue { get; set; }

    public AppUser User { get; set; }
}

internal sealed class UserDefinedCompositionConfiguration : IEntityTypeConfiguration<UserDefinedComposition>
{
    public void Configure(EntityTypeBuilder<UserDefinedComposition> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.User);

        builder.HasOne(e => e.Emotion)
            .WithMany(e => e.UserDefinedCompositions);

        builder.HasOne(e => e.PartEmotion);
    }
}
