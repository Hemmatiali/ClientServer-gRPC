namespace ClientServer_gRPC_Client.Domain.Models;

/// <summary>
///     Represents a student entity for update operations. 
/// </summary>//todo change these are models
public record StudentForUpdateModel
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}