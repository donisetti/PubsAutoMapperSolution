using PubsDomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsDomainLibrary.Concrete
{
    public class PubsDbContext: DbContext
    {
        public PubsDbContext() : base("PubsConnection") { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
    }
}
