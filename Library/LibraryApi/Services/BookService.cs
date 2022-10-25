using Grpc.Core;
using LibraryApi;

namespace LibraryApi.Services
{
    public class BookService : BookCatalog.BookCatalogBase
    {
        private readonly ILogger<BookService> _logger;
        public BookService(ILogger<BookService> logger)
        {
            _logger = logger;
        }
        public override Task<BookDetailsReply> GetBookDetails(
                   BookDetailsRequest request, ServerCallContext context)
        {
            var booksDetail = new BookDetailsReply
            {
                Id = request.Id,
                Name = "Element of Reusable Object-Oriented Software"

            };

            var authors = new List<Author>()
            {
                new Author() { Firstname = "Erich",  Lastname = "Gamma"},
                new Author() { Firstname = "Richard",  Lastname = "Helm"},
                new Author() { Firstname = "Ralph",  Lastname = "Johnson"},
                new Author() { Firstname = "John",  Lastname = "Vlissides"},
            };

            booksDetail.Authors.AddRange(authors);

            return Task.FromResult(booksDetail);
        }
    }
}