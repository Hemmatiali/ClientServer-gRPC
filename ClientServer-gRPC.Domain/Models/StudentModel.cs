namespace ClientServer_gRPC.Domain.Models;

/// <summary>
///     Represents a student model.
/// </summary>
public record StudentModel
{
    public int Id { get; init; }
    public string StudentNumber { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public List<string> PhoneNumbers { get; init; } = [];
}