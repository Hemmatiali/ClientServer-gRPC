using ClientServer_gRPC.Domain.Models;
using ClientServer_gRPC.Domain.Services;
using ClientServer_gRPC.gRPC.Protos.v1;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace grpcServices;

public class StudentService(IStudentService studentService)
    : ClientServer_gRPC.gRPC.Protos.v1.StudentService.StudentServiceBase
{
    // Services
    private readonly IStudentService _studentService = studentService;

    #region Methods

    public override async Task GetAll(Empty request, IServerStreamWriter<StudentReply> responseStream, ServerCallContext context)
    {
        var students = await _studentService.GetAllAsync();
        foreach (var student in students)
        {
            var reply = new StudentReply()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Description = student.Description,
                StudentNumber = student.StudentNumber,
            };

            reply.PhoneNumbers.AddRange(student.PhoneNumbers);
            await responseStream.WriteAsync(reply);
        }
        await Task.CompletedTask;
    }

    public override async Task<StudentReply> GetById(GetByIdRequest request, ServerCallContext context)
    {
        var student = await _studentService.GetByIdAsync(request.Id);
        if (student is null)
        {
            throw new RpcException(new Status(statusCode: StatusCode.NotFound, detail: $"Student with id {request.Id} not found"));
        }

        var reply = new StudentReply()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Description = student.Description,
            StudentNumber = student.StudentNumber,
        };

        reply.PhoneNumbers.AddRange(student.PhoneNumbers);
        return reply;
    }

    public override async Task Create(IAsyncStreamReader<CreateStudentRequest> requestStream, IServerStreamWriter<CreateStudentResponse> responseStream, ServerCallContext context)
    {
        await foreach (var item in requestStream.ReadAllAsync())
        {
            var serviceResult = await _studentService.CreateAsync(new StudentModel()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                StudentNumber = item.StudentNumber,
                Description = item.Description,
                PhoneNumbers = new List<string>(item.PhoneNumbers)
            });

            await responseStream.WriteAsync(new CreateStudentResponse()
            {
                Id = serviceResult
            });
        }

        await Task.CompletedTask;
    }

    public override async Task<UpdateStudentResponse> Update(UpdateStudentRequest request, ServerCallContext context)
    {
        var serviceResult = await _studentService.UpdateAsync(new StudentForUpdateModel()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Description = request.Description
        });
        return new UpdateStudentResponse
        {
            Success = serviceResult
        };
    }

    public override async Task<DeleteStudentResponse> Delete(DeleteStudentRequest request, ServerCallContext context)
    {
        var serviceResult = await _studentService.DeleteAsync(request.Id);
        return new DeleteStudentResponse
        {
            Success = serviceResult
        };
    }

    #endregion
}