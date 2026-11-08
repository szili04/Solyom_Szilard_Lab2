using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solyom_Szilard_Lab2.Models;

namespace Solyom_Szilard_Lab2.Pages.MemberPages
{
    public class CreateModel : PageModel
    {
        private readonly Solyom_Szilard_Lab2Context _context;

        public CreateModel(Solyom_Szilard_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}