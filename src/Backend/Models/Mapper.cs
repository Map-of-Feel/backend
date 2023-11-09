using Database.Models;

using Riok.Mapperly.Abstractions;

namespace Backend.Models;

[Mapper]
public static partial class Mapper
{
    public static partial EmotionDto Map(this Emotion emotion);

    public static partial Emotion Map(this EmotionDto emotionDto);

    public static partial IEnumerable<EmotionDto> Map(this IEnumerable<Emotion> emotions);

    public static partial IEnumerable<Emotion> Map(this IEnumerable<EmotionDto> emotions);
}