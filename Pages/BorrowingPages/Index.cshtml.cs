using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Solyom_Szilard_Lab2.Models;

namespace Solyom_Szilard_Lab2.Pages.BorrowingPages
{
    public class IndexModel : PageModel
    {
        private readonly Solyom_Szilard_Lab2Context _context;

        public IndexModel(Solyom_Szilard_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b => b!.Author)
                .Include(b => b.Member)
                .ToListAsync();
        }
    }
}