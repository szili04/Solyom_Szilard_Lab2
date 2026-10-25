using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Solyom_Szilard_Lab2.Models;

namespace Solyom_Szilard_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Solyom_Szilard_Lab2Context _context;

    public IndexModel(Solyom_Szilard_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
