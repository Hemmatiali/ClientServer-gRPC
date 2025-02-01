using ClientServer_gRPC_Client.Domain.Models;

namespace ClientServer_gRPC_Client.Domain.Repositories;

/// <summary>
///     Defines the contract for the student repository, providing CRUD operations for <see cref="StudentModel"/> entities.
/// </summary>
public interface IStudentRepository
{
    #region Retrieval Methods

    /// <summary>
    ///     Retrieves all students asynchronously as a stream.
    /// </summary>
    /// <returns>An asynchronous stream of students.</returns>
    IAsyncEnumerable<StudentModel> GetAllAsync();

    /// <summary>
    ///     Retrieves a student by ID asynchronously.
    /// </summary>
    /// <param name="id">The student ID.</param>
    /// <returns>The student model.</returns>
    Task<StudentModel> GetByIdAsync(int id);

    #endregion

    #region Creation & Modification Methods

    /// <summary>
    ///     Creates multiple students asynchronously and returns their IDs.
    /// </summary>
    /// <param name="students">The list of students to create.</param>
    /// <returns>An asynchronous stream of created student IDs.</returns>
    IAsyncEnumerable<int> CreateAsync(IEnumerable<StudentModel> students);

    /// <summary>
    ///     Deletes a student by ID asynchronously.
    /// </summary>
    /// <param name="id">The student ID.</param>
    Task DeleteAsync(int id);

    /// <summary>
    ///     Updates an existing student asynchronously.
    /// </summary>
    /// <param name="student">The student data to update.</param>
    Task UpdateAsync(StudentForUpdateModel student);

    #endregion
}