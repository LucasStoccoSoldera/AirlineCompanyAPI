namespace AirlineCompanyAPI.Config
{
    public class ApplicationData(IConfiguration configuration)
    {
        public const string JsonKey = "ApplicationData";

        public string Name => configuration[JsonKey + ":Name"] ?? String.Empty;
        public string Version => configuration[JsonKey + ":Version"] ?? String.Empty;
        public string Description => configuration[JsonKey + ":Description"] ?? String.Empty;
        public ApplicationContact? Contact => configuration.GetSection(ApplicationContact.JsonKey).Get<ApplicationContact>();
    }
}
