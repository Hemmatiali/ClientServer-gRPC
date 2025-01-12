using ClientServer_gRPC_Client.Domain.Models;

namespace ClientServer_gRPC_Client.Domain.Services;

/// <summary>
///     Defines the contract for the student service, which serves as 
///     a business layer for handling student-related operations.
/// </summary>//todo change these are clients service
public interface IStudentService
{
    #region Retrieval Methods

    Task<IList<StudentModel>> GetAllAsync();

    Task<StudentModel> GetByIdAsync(int id);

    #endregion

    #region Creation & Modification Methods

    Task CreateAsync(IEnumerable<StudentModel> students);

    Task DeleteAsync(int id);

    Task UpdateAsync(StudentForUpdateModel student);

    #endregion
}