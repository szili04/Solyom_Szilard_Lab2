using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Solyom_Szilard_Lab2.Models;

namespace Solyom_Szilard_Lab2.Pages.MemberPages
{
    public class DetailsModel : PageModel
    {
        private readonly Solyom_Szilard_Lab2Context _context;

        public DetailsModel(Solyom_Szilard_Lab2Context context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            Member = member;
            return Page();
        }
    }
}