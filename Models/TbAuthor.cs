using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbAuthor
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Bio { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TbBook> TbBooks { get; set; } = new List<TbBook>();
}
