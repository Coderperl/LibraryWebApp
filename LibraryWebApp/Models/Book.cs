using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryWebApp.Models
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? CategoryId { get; set; }
        public long? AuthorId { get; set; }
        public long? AttributeId { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
