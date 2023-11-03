using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(512)]
        public required string Title { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        [Display(Name = "Image")]
        public byte[]? CoverImage { get; internal set; }
        public string? CoverImagePath { get; set; }

        public ICollection<BooksCategory> Category { get; set; }

    }
}
