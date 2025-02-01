using ClientServer_gRPC_Client.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientServer_gRPC_Client.WebUi.Pages.Students;

/// <summary>
///     Represents the page model for deleting students.
/// </summary>
public class DeleteModel : PageModel
{
    // Services
    private readonly IStudentService _studentService;

    [BindProperty]
    public int StudentId { get; set; }

    public DeleteModel(IStudentService studentService)
    {
        _studentService = studentService;
    }

    /// <summary>
    ///     Handles GET requests for the delete page.
    /// </summary>
    public void OnGet(int id)
    {
        StudentId = id;
    }

    /// <summary>
    ///     Handles POST requests to upload and delete student records.
    /// </summary>
    /// <returns>A redirect to the index page.</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        if (StudentId > 0)
        {
            await _studentService.DeleteAsync(StudentId);
        }
        return RedirectToPage("Index");
    }
}