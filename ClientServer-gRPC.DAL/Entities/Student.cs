namespace ClientServer_gRPC.DAL.Entities;

/// <summary>
///     Represents a student entity in the database.
/// </summary>
public class Student
{
    public int Id { get; init; }
    public string StudentNumber { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public List<PhoneNumber> PhoneNumbers { get; init; } = [];
}