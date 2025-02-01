using ClientServer_gRPC_Client.DAL.Protos.v1;
using ClientServer_gRPC_Client.Domain.Models;
using ClientServer_gRPC_Client.Domain.Repositories;
using Grpc.Core;

namespace ClientServer_gRPC_Client.DAL.Repositories;

/// <inheritdoc cref="IStudentRepository"/>
public class StudentRepository : IStudentRepository
{
    // Services
    private readonly ClientServer_gRPC_Client.DAL.Protos.v1.StudentService.StudentServiceClient _studentServiceClient;

    public StudentRepository(StudentService.StudentServiceClient studentServiceClient)
    {
        _studentServiceClient = studentServiceClient;
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<StudentModel> GetAllAsync()
    {
        var request = _studentServiceClient.GetAll(new Google.Protobuf.WellKnownTypes.Empty());
        while (await request.ResponseStream.MoveNext())
        {
            var reply = request.ResponseStream.Current;
            var student = new StudentModel()
            {
                Id = reply.Id,
                FirstName = reply.FirstName,
                LastName = reply.LastName,
                Description = reply.Description,
                StudentNumber = reply.StudentNumber
            };

            student.PhoneNumbers.AddRange(reply.PhoneNumbers);
            yield return student;
        }
    }

    /// <inheritdoc />
    public async Task<StudentModel> GetByIdAsync(int id)
    {
        var result = await _studentServiceClient.GetByIdAsync(new GetByIdRequest() { Id = id });
        var finalResult = new StudentModel()
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Description = result.Description,
            StudentNumber = result.StudentNumber
        };

        finalResult.PhoneNumbers.AddRange(result.PhoneNumbers);
        return finalResult;
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<int> CreateAsync(IEnumerable<StudentModel> students)
    {
        var request = _studentServiceClient.Create();
        foreach (var student in students)
        {
            CreateStudentRequest studentRequest = new CreateStudentRequest()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Description = student.Description,
                StudentNumber = student.StudentNumber,
            };

            studentRequest.PhoneNumbers.AddRange(student.PhoneNumbers);
            await request.RequestStream.WriteAsync(studentRequest);
        }

        await request.RequestStream.CompleteAsync();
        while (await request.ResponseStream.MoveNext())
        {
            var studentResponse = request.ResponseStream.Current;
            yield return studentResponse.Id;
        }
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        await _studentServiceClient.DeleteAsync(new DeleteStudentRequest() { Id = id });
    }

    /// <inheritdoc />
    public async Task UpdateAsync(StudentForUpdateModel student)
    {
        await _studentServiceClient.UpdateAsync(new UpdateStudentRequest()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Description = student.Description
        });
    }
}