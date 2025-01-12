namespace ClientServer_gRPC.DAL.Entities;

/// <summary>
///     Represents a phone number entity in the database.
/// </summary>
public class PhoneNumber
{
    public int Id { get; init; }
    public string Value { get; init; } = string.Empty;
}