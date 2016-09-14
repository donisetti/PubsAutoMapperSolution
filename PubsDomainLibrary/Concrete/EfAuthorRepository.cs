using PubsDomainLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubsDomainLibrary.Entities;

namespace PubsDomainLibrary.Concrete
{
    public class EfAuthorRepository : IAuthorRepository
    {
        PubsDbContext _context;
        public EfAuthorRepository()
        {
            _context = new PubsDbContext();
            _context.Database.Log = (c) => { System.Diagnostics.Debug.WriteLine(c); };
        }

        #region IAuthorRepository Members
        public IQueryable<Author> Authors
        {
            get
            {
                return _context.Authors;
            }
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Entry<Author>(author).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        } 

        public void Update(List<Author> authorList)
        {
            foreach (var item in authorList)
            {
                _context.Entry<Author>(item).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
