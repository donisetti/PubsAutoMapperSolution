using PubsDomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsDomainLibrary.Abstract
{
    public interface IAuthorRepository
    {
        IQueryable<Author> Authors { get; }
        void Add(Author author);
        void Delete(Author author);
        void Update(Author author);
        void Update(List<Author> authorList);
    }
}
