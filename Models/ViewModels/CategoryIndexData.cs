using Solyom_Szilard_Lab2.Models;

namespace Solyom_Szilard_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}