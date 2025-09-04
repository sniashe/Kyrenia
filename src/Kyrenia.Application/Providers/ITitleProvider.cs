using Kyrenia.Application.Models;

namespace Kyrenia.Application.Providers;

public interface ITitleProvider
{
    Task<TitleDetails> GetByExternalIdAsync(string id);

    Task<IEnumerable<TitleSummary>> GetAllAsync(GetTitlesOptions options);
}
