using ClientServer_gRPC_Client.Domain.Models;
using ClientServer_gRPC_Client.Domain.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientServer_gRPC_Client.WebUi.Pages.Students;

public class IndexModel : PageModel
{
    private readonly IStudentService _studentService;
    public IEnumerable<StudentModel> Students { get; set; }

    public IndexModel(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task OnGet()
    {
        Students = await _studentService.GetAllAsync();
    }
}