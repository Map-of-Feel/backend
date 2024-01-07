namespace Backend.Models;

public sealed class EmotionDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsCoreEmotion { get; set; }

    public string Color { get; set; } = null!;

    public IList<LocalizedEmotionInfoDto> LocalizedInfos { get; set; } = Array.Empty<LocalizedEmotionInfoDto>();

    public IList<EmotionDefaultComposePartDto> DefaultComposeParts { get; set; } = new List<EmotionDefaultComposePartDto>();

    public IList<UserDefinedCompositionDto> UserDefinedCompositions { get; set; } = new List<UserDefinedCompositionDto>();
}
