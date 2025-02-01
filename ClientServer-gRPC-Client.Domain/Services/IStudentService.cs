using ClientServer_gRPC_Client.Domain.Models;

namespace ClientServer_gRPC_Client.Domain.Services;

/// <summary>
///     Defines the contract for the student service, handling student-related operations.
/// </summary>
public interface IStudentService
{
    #region Retrieval Methods

    /// <summary>
    ///     Retrieves all students asynchronously.
    /// </summary>
    /// <returns>A list of students.</returns>
    Task<IList<StudentModel>> GetAllAsync();

    /// <summary>
    ///     Retrieves a student by ID asynchronously.
    /// </summary>
    /// <param name="id">The student ID.</param>
    /// <returns>The student model.</returns>
    Task<StudentModel> GetByIdAsync(int id);

    #endregion

    #region Creation & Modification Methods

    /// <summary>
    ///     Creates multiple students asynchronously.
    /// </summary>
    /// <param name="students">The list of students to create.</param>
    Task CreateAsync(IEnumerable<StudentModel> students);

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