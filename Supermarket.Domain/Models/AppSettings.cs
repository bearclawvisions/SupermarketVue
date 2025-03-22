namespace Supermarket.Domain.Models;

public class AppSettings
{
    public string Test { get; init; } = string.Empty;
    public ConnectionStringsSettings ConnectionStrings { get; init; } = new();
    
    public class ConnectionStringsSettings
    {
        public string DefaultConnection { get; init; } = string.Empty;
    }
}