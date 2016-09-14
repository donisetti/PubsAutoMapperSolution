using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsDomainLibrary.Entities
{
    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

    }
}
