namespace ClientServer_gRPC.Domain.Models;

/// <summary>
///     Represents a student entity for update operations. 
/// </summary>
public record StudentForUpdateModel
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}