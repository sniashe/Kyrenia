namespace Kyrenia.Api;

public static class ApiEndpoints
{
    private const string ApiBase = $"api";

    public static class Titles
    {
        private const string Base = $"{ApiBase}/titles";

        public const string Get = $"{Base}/id";
        public const string GetAll = Base;
    }
}
