using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryWebApp.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string AuthorName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
