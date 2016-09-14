using PubsDomainLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubsDomainLibrary.Entities;

namespace PubsDomainLibrary.Concrete
{
    public class EfBookRepository : IBookRepository
    {
        PubsDbContext _context;
        public EfBookRepository()
        {
            _context = new PubsDbContext();
           _context.Database.Log = (c) => { System.Diagnostics.Debug.WriteLine(c); };
        }

        public IQueryable<Book> Books
        {
            get
            {
                return _context.Books;
            }
        }

        public void Add(Book book)
        {
            //2 context's were used before sending the book data from BookController hence this will cause a problem
            _context.Entry<Book>(book).State = System.Data.Entity.EntityState.Detached;
            book.Authors = null;
            var authorList = new List<Author>();
            foreach (var item in book.Authors)
            {
                authorList.Add(item);
            }
            //_context.Books.Attach(book);
            book.Authors = authorList;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void Add(Book book, List<Author> authorList)
        {
            //2 context's were used before sending the book data from BookController hence this will cause a problem
            book.Authors = authorList;
            _context.Books.Add(book);
            _context.SaveChanges();
            
        }

        public void Add(Book book, int[] authorIds)
        {

            var dbAuthorList = _context.Authors;
            List<Author> authorList = new List<Author>();
            for (int i = 0; i < authorIds.Count(); i++)
            {
                int authorId = authorIds[i];
                authorList.Add(dbAuthorList.FirstOrDefault(a=>a.AuthorId == authorId));
            }
            book.Authors = authorList;
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Entry<Book>(book).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
