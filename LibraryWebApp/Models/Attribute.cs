using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryWebApp.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Available { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
