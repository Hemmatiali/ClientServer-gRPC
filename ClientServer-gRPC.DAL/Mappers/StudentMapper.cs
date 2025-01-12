using ClientServer_gRPC.DAL.Entities;
using ClientServer_gRPC.Domain.Models;

namespace ClientServer_gRPC.DAL.Mappers;

/// <summary>
///     Provides mapping extensions for student entities and models.
/// </summary>
public static class StudentMapper
{
    /// <summary>
    ///     Converts a student entity to a student model.
    /// </summary>
    /// <param name="student">The student entity to convert.</param>
    /// <returns>The converted student model.</returns>
    public static StudentModel ToModel(this Student student)
    {
        return new StudentModel()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Description = student.Description,
            StudentNumber = student.StudentNumber,
            PhoneNumbers = student.PhoneNumbers.Select(x => x.Value).ToList()
        };
    }
}