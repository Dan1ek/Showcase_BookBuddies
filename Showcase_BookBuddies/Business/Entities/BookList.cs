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

    }
}