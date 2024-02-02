namespace AirlineCompanyAPI.Config
{
    public class ApplicationContact(IConfiguration configuration)
    {
        public const string JsonKey = $"{ApplicationData.JsonKey}.Contact";

        public string Name => configuration[JsonKey + ":Name"] ?? String.Empty;
        public string? Url => configuration[JsonKey + ":Url"];
    }
}
