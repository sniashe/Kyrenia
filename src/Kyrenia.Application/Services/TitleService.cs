using Kyrenia.Application.Models;
using Kyrenia.Application.Providers;

namespace Kyrenia.Application.Services;

internal class TitleService : ITitleService
{
    private readonly ITitleProvider _titleProvider;

    public TitleService(ITitleProvider titleProvider)
    {
        _titleProvider = titleProvider;
    }

    public async Task<IEnumerable<TitleSummary>> GetAllAsync(string title)
    {
        var options = new GetTitlesOptions
        {
            Name = title
        };

        var response = await _titleProvider.GetAllAsync(options);

        return response;
    }

    public async Task<TitleDetails> GetByExternalIdAsync(string id)
    {
        var response = await _titleProvider.GetByExternalIdAsync(id);

        return response;
    }
}
