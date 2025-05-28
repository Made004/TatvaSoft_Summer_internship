namespace day03.Services
{
    using System.Xml.Linq;
    using day03.Model;

   
        public class BookService
        {
            private readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "The Alchemist", Genre = "Fiction" },
            new Book { Id = 2, Title = "Clean Code", Genre = "Programming" },
        };

            public IEnumerable<Book> GetAll() => _books;

            public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

            public void Add(Book book)
            {
                book.Id = _books.Max(b => b.Id) + 1;
                _books.Add(book);
            }

            public void Update(int id, Book updatedBook)
            {
                var book = GetById(id);
                if (book is null) return;

                book.Title = updatedBook.Title;
                book.Genre = updatedBook.Genre;
            }

            public void Delete(int id)
            {
                var book = GetById(id);
                if (book is not null)
                    _books.Remove(book);
            }
        }
    }


