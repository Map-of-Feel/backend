using Database.Data;
using Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public interface IEmotionService
{
    Task<IReadOnlyList<Emotion>> GetAllEmotionsAsync();

    Task<Emotion> AddEmotion(Emotion emotion);
}

public sealed class EmotionService : IEmotionService
{
    private readonly ILogger<EmotionService> _logger;
    private readonly MapOfFeelContext _context;

    public EmotionService(
        ILogger<EmotionService> logger,
        MapOfFeelContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<Emotion> AddEmotion(Emotion emotion)
    {
        var newEntity = _context.Emotions.Add(emotion);

        _ = await _context.SaveChangesAsync();

        return newEntity.Entity;
    }

    public async Task<IReadOnlyList<Emotion>> GetAllEmotionsAsync()
    {
        var emotions = await _context.Emotions.ToListAsync();

        return emotions.AsReadOnly();
    }
}