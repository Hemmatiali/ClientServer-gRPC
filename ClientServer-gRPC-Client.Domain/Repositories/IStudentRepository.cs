using ClientServer_gRPC_Client.Domain.Models;

namespace ClientServer_gRPC_Client.Domain.Repositories;

/// <summary>
///     Defines the contract for the student repository, which provides
///     CRUD operations for <see cref="StudentModel"/> entities.
/// </summary>//todo change these are clients service
public interface IStudentRepository
{
    #region Retrieval Methods

//todo xml
    IAsyncEnumerable<StudentModel> GetAllAsync();

//todo xml
    Task<StudentModel> GetByIdAsync(int id);

    #endregion

    #region Creation & Modification Methods

//todo xml
    IAsyncEnumerable<int> CreateAsync(IEnumerable<StudentModel> students);

    //todo xml
    Task DeleteAsync(int id);

    //todo xml
    Task UpdateAsync(StudentForUpdateModel student);

    #endregion

}