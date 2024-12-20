using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbBook
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int? AuthorId { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public string? NameAuthor { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsNew { get; set; }

    public int? IsStar { get; set; }

    public string? Alias { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsBestSeller { get; set; }

    public virtual TbAuthor? Author { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();
}
