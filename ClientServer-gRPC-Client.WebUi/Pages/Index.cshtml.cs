using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientServer_gRPC_Client.WebUi.Pages;

/// <summary>
///     Represents the page model for list of students.
/// </summary>
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     Handles GET requests for the index page.
    /// </summary>
    public void OnGet()
    { }
}