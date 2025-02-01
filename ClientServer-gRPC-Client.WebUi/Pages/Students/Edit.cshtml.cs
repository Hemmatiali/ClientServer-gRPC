using ClientServer_gRPC_Client.Domain.Models;
using ClientServer_gRPC_Client.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientServer_gRPC_Client.WebUi.Pages.Students;

/// <summary>
///     Represents the page model for editing students.
/// </summary>
public class EditModel : PageModel
{
    // Services
    private readonly IStudentService _studentService;

    [BindProperty]
    public StudentForUpdateModel Student { get; set; } = new();

    public EditModel(IStudentService studentService)
    {
        _studentService = studentService;
    }

    /// <summary>
    ///     Handles GET requests for the edit page.
    /// </summary>
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        Student = new StudentForUpdateModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Description = student.Description
        };

        return Page();
    }

    /// <summary>
    ///     Handles POST requests to upload and edit student records.
    /// </summary>
    /// <returns>A redirect to the index page.</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _studentService.UpdateAsync(Student);
        return RedirectToPage("Index");
    }
}