using ClientServer_gRPC.Domain.Models;

namespace ClientServer_gRPC.Domain.Repositories;

/// <summary>
///     Defines the contract for the student repository, which provides
///     CRUD operations for <see cref="StudentModel"/> entities.
/// </summary>
public interface IStudentRepository
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
    /// <returns>The number of affected rows (1 if successful, 0 otherwise).</returns>
    Task<int> DeleteAsync(int id);

    /// <summary>
    ///     Updates an existing student record asynchronously.
    /// </summary>
    /// <param name="student">The updated student details.</param>
    /// <returns>The number of affected rows (1 if successful, 0 otherwise).</returns>
    Task<int> UpdateAsync(StudentForUpdateModel student);

    #endregion

}