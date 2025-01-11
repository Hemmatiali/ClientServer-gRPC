using ClientServer_gRPC.DAL.Entities;
using ClientServer_gRPC.Domain.Models;

namespace ClientServer_gRPC.DAL.Mappers;

//todo xml
public static class StudentMapper
{
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