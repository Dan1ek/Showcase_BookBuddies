using Showcase_BookBuddies.Business.Validation;
using System.ComponentModel.DataAnnotations;

namespace Showcase_BookBuddies.Business.Entities
{
    public class BookList
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.Required)]
        [StringLength(200, MinimumLength = 1, ErrorMessage = ValidationMessages.MinLength)]
        public string ListTitle { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.Required)]
        [StringLength(500, MinimumLength = 1, ErrorMessage = ValidationMessages.MinLength)]
        public string ListDescription { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<Book>? Books { get; set; } //list

        //public List<Book> books { get; set; }
        //public BookList(string title, string description, List<Book> books)
        //{
        //    Title = title;
        //    Description = description;
        //    Books = books ?? new List<Book>(); // Initialize an empty list if none provided
        //}

        //public void AddBook(Book book)
        //{
        //    Books.Add(book);
        //}
    }
}