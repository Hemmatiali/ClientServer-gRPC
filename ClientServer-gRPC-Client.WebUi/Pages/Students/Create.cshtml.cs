using ClientServer_gRPC_Client.Domain.Models;
using ClientServer_gRPC_Client.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ClientServer_gRPC_Client.WebUi.Pages.Students;

/// <summary>
///     Represents the page model for creating students.
/// </summary>
public class CreateModel : PageModel
{
    // Services
    private readonly IStudentService _studentService;

    [BindProperty] //tHIS file should be JSON format.
    public IFormFile StudentFile { get; set; }

    public CreateModel(IStudentService studentService)
    {
        _studentService = studentService;
    }

    /// <summary>
    ///     Handles GET requests for the create page.
    /// </summary>
    public void OnGet()
    {
    }

    /// <summary>
    ///     Handles POST requests to upload and create student records.
    /// </summary>
    /// <returns>A redirect to the index page.</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        var path = @$"d:\{DateTime.Now.Ticks}.json";
        await using (var stream = System.IO.File.Create(path))
        {
            await StudentFile.CopyToAsync(stream);
        }

        var text = await System.IO.File.ReadAllTextAsync(path);
        var students = JsonConvert.DeserializeObject<List<StudentModel>>(text);
        if (students != null) await _studentService.CreateAsync(students);

        return RedirectToPage("Index");
    }
}