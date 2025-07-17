namespace Kyrenia.Client.Services;

public class MediaSearchHistoryService
{
    private readonly int _maxHistorySize = 5;
    private readonly List<string> _history = new();

    public IReadOnlyCollection<string> GetHistory() => _history.AsReadOnly();

    public void AddQuery(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return;
        }

        var matchedQuery = _history.FirstOrDefault(h => string.Equals(h, query, StringComparison.OrdinalIgnoreCase));
        if (matchedQuery != null)
        {
            _history.Remove(matchedQuery);
        }

        _history.Insert(0, query);

        if (_history.Count > _maxHistorySize)
        {
            _history.RemoveAt(_history.Count - 1);
        }
    }
}
