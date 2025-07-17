using Kyrenia.Contracts.DTOs;

namespace Kyrenia.Client.Services;

public class MediaSearchStore
{
    public MediaSearchResultDto? LatestResult { get; private set; }

    public event Action? OnLatestResultUpdated;

    public void SetResult(MediaSearchResultDto result)
    {
        LatestResult = result;
        OnLatestResultUpdated?.Invoke();
    }
}
