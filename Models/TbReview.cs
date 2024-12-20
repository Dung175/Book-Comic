using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbReview
{
    public int ReviewId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbBook? Book { get; set; }

    public virtual TbUser? User { get; set; }
}
