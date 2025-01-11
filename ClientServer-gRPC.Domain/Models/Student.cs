namespace ClientServer_gRPC.Domain.Models;

/// <summary>
///     Represents a student entity used for CRUD operations. 
///     This record acts as a Data Transfer Object (DTO), 
///     as there is no business logic in the domain.
/// </summary>
public record Student
{
    public int Id { get; init; }
    public string StudentNumber { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}