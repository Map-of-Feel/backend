namespace Backend.Models;

public class UserDefinedCompositionDto
{
    public Guid Id { get; set; }

    public EmotionDto PartEmotion { get; set; } = null!;

    public decimal PartValue { get; set; }

    public AppUserDto User { get; set; }
}