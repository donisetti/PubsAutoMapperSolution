using PubsDomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsDomainLibrary.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        void Add(Book book);
        void Add(Book book, List<Author> authorList);
        void Add(Book book, int[] authorIds);
        void Delete(Book book);
        void Update(Book book);
    }
}
