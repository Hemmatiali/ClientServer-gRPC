﻿using ClientServer_gRPC.Domain.Services;
using ClientServer_gRPC.Domain.Models;
using ClientServer_gRPC.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ClientServer_gRPC.BLL.Services;

/// <summary>
///     Provides implementation for <see cref="IStudentService"/>, 
///     handling CRUD operations for students.
/// </summary>
public class StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
    : IStudentService
{
    // Services
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly ILogger<StudentService> _logger = logger;

    /// <inheritdoc />
    public async Task<IEnumerable<StudentModel>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    /// <inheritdoc />
    public async Task<StudentModel> GetByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    /// <inheritdoc />
    public async Task<int> CreateAsync(StudentModel studentModel)
    {
        var result = await _studentRepository.CreateAsync(studentModel);
        _logger.LogDebug($"StudentModel created with studentId {result}.");
        return result;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _studentRepository.DeleteAsync(id);
        return result == 1;
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync(StudentForUpdateModel student)
    {
        var result = await _studentRepository.UpdateAsync(student);
        return result == 1;
    }
}