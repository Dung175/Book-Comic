using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbAbout
{
    public int AboutId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? ImageUrl { get; set; }

    public string? Decription { get; set; }

    public bool? IsActive { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
