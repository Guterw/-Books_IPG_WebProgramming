using Books.Models;
using Microsoft.EntityFrameworkCore;
namespace Books.Data
{
    public static class SeedData
    {
        public static void PopulateBooks(BooksDbContext db)
        {
            if (db.Book.Any())
            {
                return;
            }

            Author authorJKR = db.Author.FirstOrDefault(a => a.Name == "J. K. Rowling")!;

            db.Book.AddRange(
            new Book
                {
                    Title = "Harry Potter e a Pedra Filosofal",
                    Description = "Orfão de pais e rejeitado pelos tios, Harry Potter vivia uma vida banal até que na noite do seu 11º aniversário é surpreendido com a notícia que é um feiticeiro e que o aguardam na Escola de Magia e Feitiçaria em Hogwarts. Dando assim o início a uma grande aventura!",
                    AuthorId = 1,
                },
            new Book
                {
                    Title = "Harry Potter e o Calice de Fogo",
                    Description = "Teste",
                    AuthorId = 1,
                }
                );
            db.SaveChanges();
            {
                PopulateBooks(db);
            }
        }
    }
}
