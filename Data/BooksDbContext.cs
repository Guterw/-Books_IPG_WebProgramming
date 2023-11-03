using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Books.Models;

namespace Books.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext (DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Books.Models.Book> Book { get; set; } = default!;

        public DbSet<Books.Models.Author> Author { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BooksCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
        }

        public DbSet<Books.Models.Category> Category { get; set; }
    }
}
