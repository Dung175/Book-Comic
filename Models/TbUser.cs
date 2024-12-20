using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbUser
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string Email { get; set; } = null!;

    public string? Message { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbAccount? TbAccount { get; set; }

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();

    public virtual ICollection<TbUserActivity> TbUserActivities { get; set; } = new List<TbUserActivity>();
}
