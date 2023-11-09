namespace Backend.Models;

public sealed class EmotionDto
{
    public Guid Id { get; set; }

    /// <summary>
    /// The english name of the emotion
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public bool IsCoreEmotion { get; set; }
}
