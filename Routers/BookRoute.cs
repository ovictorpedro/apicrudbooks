using Books.Data;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Routers
{
    public static class BookRoute
    {
        public static void BooksRoutes(this WebApplication app)
        {
            var route = app.MapGroup("books");

            route.MapGet("",
               async (BookContext context) =>
               {
                   var books = await context.Books.ToListAsync();

                   return Results.Ok(books);
               });

            route.MapPost("",
                async (BookRequest req, BookContext context) =>
                {
                    var book = new BookModel(req.title);
                    await context.AddAsync(book);
                    await context.SaveChangesAsync();
                });

            route.MapPut("{id:guid}",
                async (Guid id, BookRequest req, BookContext context) =>
                {
                    var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);

                    if (book == null)
                        return Results.NotFound();

                    book.ChangeTitle(req.title);
                    await context.SaveChangesAsync();

                    return Results.Ok(book);
                });

            route.MapDelete("{id:guid}",
               async (Guid id, BookContext context) =>
               {
                   var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);

                   if (book == null)
                       return Results.NotFound();

                   context.Books.Remove(book);
                   await context.SaveChangesAsync();

                   return Results.Ok(book);
               });
        }
    }
}