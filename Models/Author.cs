using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 4)]
        public required string Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
