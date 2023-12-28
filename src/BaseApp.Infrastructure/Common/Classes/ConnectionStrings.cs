namespace BaseApp.Infrastructure.Common.Classes
{
    public class DatabaseSettings
    {
        public const string SectionName = "Database";

        public string ConnectionString { get; init; } = null!;
    }
}
