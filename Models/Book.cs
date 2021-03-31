using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManagement.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
