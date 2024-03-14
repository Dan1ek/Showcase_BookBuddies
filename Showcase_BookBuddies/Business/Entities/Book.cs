using Showcase_BookBuddies.Business.Validation;
using System.ComponentModel.DataAnnotations;

namespace Showcase_BookBuddies.Business.Entities
{
    public class Book
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.Required)]
        [StringLength(200, MinimumLength = 1, ErrorMessage = ValidationMessages.MinLength)]
        public string Titel { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.Required)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = ValidationMessages.MinLength)]
        public string Author { get; set; }
    }
}