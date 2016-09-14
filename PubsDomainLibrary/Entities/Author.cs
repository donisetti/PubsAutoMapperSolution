using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsDomainLibrary.Entities
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
