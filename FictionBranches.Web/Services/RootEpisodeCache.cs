using Coravel.Invocable;
using FictionBranches.Web.Data;
using FictionBranches.Web.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FictionBranches.Web.Services;

public class RootEpisodeCache
{
    private Dictionary<long, Fbepisode> _episodes = [];

    public IEnumerable<Fbepisode> Roots => _episodes.Values;

    public Fbepisode? GetEpisode(long episodeId)
    {
        return _episodes.TryGetValue(episodeId, out var episode) ? episode : null;
    }

    public Fbepisode? GetEpisodeFromNewMap(string? newMap)
    {
        try
        {
            return newMap == null ? null : GetEpisode(long.Parse(newMap[1..].Split('B')[0]));
        }
        catch
        {
            return null;
        }
    }
    
    public async Task Reload(ApplicationDbContext dbContext)
    {
        _episodes = await dbContext.Fbepisodes
            .Where(e => e.ParentGeneratedid == null)
            .OrderBy(e => e.Date)
            .ToDictionaryAsync(e => e.Generatedid, e => e);
    }
}

public class RootEpisodeCacheUpdater(RootEpisodeCache rootEpisodeCache, ApplicationDbContext dbContext) : IInvocable
{
    public async Task Invoke()
    {
        await rootEpisodeCache.Reload(dbContext);
    }
}