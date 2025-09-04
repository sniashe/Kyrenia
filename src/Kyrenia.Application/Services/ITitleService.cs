using Kyrenia.Application.Models;

namespace Kyrenia.Application.Services;

public interface ITitleService
{
    Task<IEnumerable<TitleSummary>> GetAllAsync(string title);

    Task<TitleDetails> GetByExternalIdAsync(string id);
}
