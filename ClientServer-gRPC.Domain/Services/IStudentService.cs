﻿using ClientServer_gRPC.Domain.Models;

namespace ClientServer_gRPC.Domain.Services;

/// <summary>
///     Defines the contract for the student service, which serves as 
///     a business layer for handling student-related operations.
/// </summary>
public interface IStudentService
{
    #region Retrieval Methods

    /// <summary>
    ///     Retrieves all students asynchronously.
    /// </summary>
    /// <returns>A collection of all students.</returns>
    Task<IEnumerable<StudentModel>> GetAllAsync();

    /// <summary>
    ///     Retrieves a student by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the student.</param>
    /// <returns>The student entity if found.</returns>
    Task<StudentModel> GetByIdAsync(int id);

    #endregion

    #region Creation & Modification Methods

    /// <summary>
    ///     Creates a new studentModel record asynchronously.
    /// </summary>
    /// <param name="studentModel">The studentModel to create.</param>
    /// <returns>The ID of the newly created studentModel.</returns>
    Task<int> CreateAsync(StudentModel studentModel);

    /// <summary>
    ///     Deletes a student by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the student to delete.</param>
    /// <returns><c>true</c> if the operation was successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeleteAsync(int id);

    /// <summary>
    ///     Updates an existing student record asynchronously.
    /// </summary>
    /// <param name="student">The updated student details.</param>
    /// <returns><c>true</c> if the operation was successful; otherwise, <c>false</c>.</returns>
    Task<bool> UpdateAsync(StudentForUpdateModel student);

    #endregion
}