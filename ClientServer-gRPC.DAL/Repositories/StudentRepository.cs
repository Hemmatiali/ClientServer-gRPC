using ClientServer_gRPC.Domain.Repositories;
using ClientServer_gRPC.DAL.Entities;
using ClientServer_gRPC.DAL.Mappers;
using ClientServer_gRPC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientServer_gRPC.DAL.Repositories;

//todo xml
public class StudentRepository(StudentDbContext studentDbContext) : IStudentRepository
{
    // Injection
    private readonly StudentDbContext _studentDbContext = studentDbContext;

    #region Methods

    public async Task<IEnumerable<StudentModel>> GetAllAsync()
    {
        return await _studentDbContext.Students.Include(c => c.PhoneNumbers).AsNoTracking()
            .Select(c => c.ToModel()).ToListAsync();
    }

    public async Task<StudentModel> GetByIdAsync(int id)
    {
        return (await _studentDbContext.Students.Include(c => c.PhoneNumbers).AsNoTracking()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync()).ToModel();
    }

    public async Task<int> CreateAsync(StudentModel studentModel)
    {
        var student = new Student()
        {
            FirstName = studentModel.FirstName,
            LastName = studentModel.LastName,
            Description = studentModel.Description,
            StudentNumber = studentModel.StudentNumber
        };

        foreach (var item in studentModel.PhoneNumbers)
        {
            student.PhoneNumbers.Add(new PhoneNumber()
            {
                Value = item
            });
        }

        await _studentDbContext.AddAsync(student);
        await _studentDbContext.SaveChangesAsync();

        return student.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var student = new Student() { Id = id };
        _studentDbContext.Remove(student);
        var result = await _studentDbContext.SaveChangesAsync();
        return result;
    }

    public async Task<int> UpdateAsync(StudentForUpdateModel studentForUpdate)
    {
        var student = new Student()
        {
            Id = studentForUpdate.Id,
            FirstName = studentForUpdate.FirstName,
            LastName = studentForUpdate.LastName,
            Description = studentForUpdate.Description
        };

        _studentDbContext.Entry(student).Property(c => c.FirstName).IsModified = true;
        _studentDbContext.Entry(student).Property(c => c.LastName).IsModified = true;
        _studentDbContext.Entry(student).Property(c => c.Description).IsModified = true;

        var result = await _studentDbContext.SaveChangesAsync();
        return result;
    }

    #endregion

}