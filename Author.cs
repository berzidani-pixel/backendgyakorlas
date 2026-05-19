using System;
using System.Collections.Generic;

namespace Farkas_Zoltán_backend.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
