using ClientServer_gRPC_Client.Domain.Models;
using ClientServer_gRPC_Client.Domain.Repositories;
using ClientServer_gRPC_Client.Domain.Services;
using Microsoft.Extensions.Logging;

namespace ClientServer_gRPC_Client.BLL.Services;

/// <inheritdoc cref="IStudentService"/>
public class StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
    : IStudentService
{
    // Services
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly ILogger<StudentService> _logger = logger;

    /// <inheritdoc />
    public async Task<IList<StudentModel>> GetAllAsync()
    {
        IList<StudentModel> result = new List<StudentModel>();
        await foreach (var student in _studentRepository.GetAllAsync())
        {
            result.Add(student);
        }
        return result;
    }

    /// <inheritdoc />
    public async Task<StudentModel> GetByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    /// <inheritdoc />
    public async Task CreateAsync(IEnumerable<StudentModel> students)
    {
        await foreach (var item in _studentRepository.CreateAsync(students))
        {
            _logger.LogInformation($"Student created by Id: {item} at datetime {DateTime.Now}");
        }

        await Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        await _studentRepository.DeleteAsync(id);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(StudentForUpdateModel student)
    {
        await _studentRepository.UpdateAsync(student);
    }
}