namespace Backend.Models;

public class EmotionDefaultComposePartDto
{
    public Guid Id { get; set; }

    public EmotionDto PartEmotion { get; set; } = null!;

    public decimal PartValue { get; set; }
}
