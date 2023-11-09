using Backend.Models;
using Backend.Services;

using Database.Models;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend;

public static class EmotionApi
{
    public static void MapEmotionApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetEmotionsAsync);
        group.MapPost("/", CreateEmotionAsync);
    }

    public static async Task<Ok<List<EmotionDto>>> GetEmotionsAsync(
        IEmotionService emotionService)
    {
        IReadOnlyList<Emotion> value = await emotionService.GetAllEmotionsAsync();

        return TypedResults.Ok(value.Map().ToList());
    }

    public static async Task<Ok<EmotionDto>> CreateEmotionAsync(
        [FromBody] EmotionDto newEmotion,
        [FromServices] IEmotionService emotionService)
    {
        var entity = Mapper.Map(newEmotion);

        entity.Id = Guid.NewGuid();
        entity = await emotionService.AddEmotion(entity);

        return TypedResults.Ok(entity.Map());
    }
}