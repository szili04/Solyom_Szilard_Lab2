namespace Solyom_Szilard_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => LastName + " " + FirstName;

        public ICollection<Book>? Books { get; set; }
    }
}
