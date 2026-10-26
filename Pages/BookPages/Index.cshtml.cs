using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Solyom_Szilard_Lab2.Models;

namespace Solyom_Szilard_Lab2.Pages.BookPages
{
    public class IndexModel : PageModel
    {
        private readonly Solyom_Szilard_Lab2Context _context;

        public IndexModel(Solyom_Szilard_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; } = default!;
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        // pasul 8
        public string TitleSort { get; set; } = string.Empty;
        public string AuthorSort { get; set; } = string.Empty;

        // pasul 11
        public string CurrentFilter { get; set; } = string.Empty;

        public async Task OnGetAsync(int? id, int? categoryID, string? sortOrder, string? searchString)
        {
            BookD = new BookData();

            // pasul 9
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";

            // pasul 12
            CurrentFilter = searchString ?? string.Empty;

            BookD.Books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            // pasul 12: filtrare
            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s =>
                    (s.Author != null && s.Author.FirstName.Contains(searchString))
                    || (s.Author != null && s.Author.LastName.Contains(searchString))
                    || s.Title.Contains(searchString));
            }

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books.Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories!.Select(s => s.Category);
            }

            // pasul 9: sortare
            switch (sortOrder)
            {
                case "title_desc":
                    BookD.Books = BookD.Books.OrderByDescending(s => s.Title);
                    break;
                case "author_desc":
                    BookD.Books = BookD.Books.OrderByDescending(s => s.Author?.FullName);
                    break;
                case "author":
                    BookD.Books = BookD.Books.OrderBy(s => s.Author?.FullName);
                    break;
                default:
                    BookD.Books = BookD.Books.OrderBy(s => s.Title);
                    break;
            }
        }
    }
}