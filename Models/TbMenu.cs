using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbMenu
{
    public int MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? ParentMenuId { get; set; }

    public string? Url { get; set; }

    public int? Order { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TbMenu> InverseParentMenu { get; set; } = new List<TbMenu>();

    public virtual TbMenu? ParentMenu { get; set; }
}
