using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using booksAPI.Services;

namespace booksAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<LibraryContext>();
            builder.Services.AddTransient<IRepository<Book>, BookRepository>();
            builder.Services.AddTransient<IRepository<User>, UserRepository>();
            builder.Services.AddHttpClient<IGutendexService, GutendexService>(client =>
            {
                client.BaseAddress = new Uri("https://gutendex.com/books");
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
