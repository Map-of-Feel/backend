using Database.Data;
using Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public interface IEmotionService
{
    Task<IReadOnlyList<Emotion>> GetAllEmotionsAsync();

    Task<Emotion> AddEmotion(Emotion emotion);

    Task DeleteEmotion(Emotion emotion);

    Task<Emotion?> ChangeEmotionName(Guid emotionId, string newName);

    Task<Emotion?> AddLocalizedInfo(Guid emotionId, LocalizedEmotionInfo localizedEmotionInfo);

    Task<LocalizedEmotionInfo> UpdateLocalizedEmotionInfo(LocalizedEmotionInfo mappedInfo);
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

    public async Task DeleteEmotion(Emotion emotion)
    {
        var entities = await _context
            .Emotions
            .Where(e => e.Id == emotion.Id)
            .ToListAsync();

        _context.Emotions.RemoveRange(entities);

        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Emotion>> GetAllEmotionsAsync()
    {
        var emotions = await _context.Emotions
            .Include(e => e.DefaultComposeParts)
            .Include(e => e.LocalizedInfos)
            .ToListAsync();

        return emotions.AsReadOnly();
    }

    public async Task<Emotion?> ChangeEmotionName(Guid emotionId, string newName)
    {
        var emotion = await _context.Emotions.FindAsync(emotionId);

        if (emotion is null)
        {
            this._logger.LogWarning("Tried updating non existing emotion {Guid}", emotionId);

            return null;
        }

        emotion.Name = newName;

        await _context.SaveChangesAsync();

        return emotion;
    }

    public async Task<Emotion?> AddLocalizedInfo(Guid emotionId, LocalizedEmotionInfo localizedEmotionInfo)
    {
        var emotion = await _context.Emotions
            .Where(e => e.Id == emotionId)
            .Include(e => e.LocalizedInfos)
            .SingleOrDefaultAsync();

        if (emotion is null)
        {
            this._logger.LogWarning("Tried updating non existing emotion {Guid}", emotionId);

            return null;
        }

        // broken
        //emotion.LocalizedInfos.Add(localizedEmotionInfo);

        //await _context.SaveChangesAsync();

        localizedEmotionInfo.Emotion = emotion;
        _context.Add(localizedEmotionInfo);
        emotion.LocalizedInfos.Add(localizedEmotionInfo);

        var y = _context.Entry(localizedEmotionInfo);

        await _context.SaveChangesAsync();

        return emotion;
    }

    public async Task<LocalizedEmotionInfo> UpdateLocalizedEmotionInfo(LocalizedEmotionInfo mappedInfo)
    {
        _context.Update(mappedInfo);

        await _context.SaveChangesAsync();

        return mappedInfo;
    }
}