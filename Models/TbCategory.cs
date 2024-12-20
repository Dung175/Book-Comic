using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TbBook> TbBooks { get; set; } = new List<TbBook>();
}
