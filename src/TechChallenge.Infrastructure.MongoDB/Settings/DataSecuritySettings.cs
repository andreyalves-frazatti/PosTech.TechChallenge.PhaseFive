namespace TechChallenge.Infrastructure.MongoDB.Settings;

public record DataSecuritySettings
{
    public string? EncryptionKey { get; set; }
}
