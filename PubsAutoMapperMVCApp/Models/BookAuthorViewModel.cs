using PubsDomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PubsAutoMapperMVCApp.Models
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public List<Author> Authors { get; set; }
    }
}