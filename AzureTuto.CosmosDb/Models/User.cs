namespace AzureTuto.CosmosDb.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Username { get; set; } = string.Empty;

    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    public Guid GroupID { get; set; }
}
