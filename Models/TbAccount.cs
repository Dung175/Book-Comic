using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbAccount
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? DateJoined { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbUser User { get; set; } = null!;
}
