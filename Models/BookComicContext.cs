using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookComic.Models;

public partial class BookComicContext : DbContext
{
    public BookComicContext()
    {
    }

    public BookComicContext(DbContextOptions<BookComicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbAuthor> TbAuthors { get; set; }

    public virtual DbSet<TbBook> TbBooks { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbReview> TbReviews { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserActivity> TbUserActivities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source= DESKTOP-RE5V29H; initial catalog=BookComic; integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tb_Accou__1788CCACFB2BBD3F");

            entity.ToTable("tb_Account");

            entity.HasIndex(e => e.Username, "UQ__tb_Accou__536C85E46E1D3679").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateJoined)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Customer");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.TbAccount)
                .HasForeignKey<TbAccount>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Accoun__UserI__778AC167");
        });

        modelBuilder.Entity<TbAuthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__tb_Autho__70DAFC1452C2534B");

            entity.ToTable("tb_Authors");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__tb_Books__3DE0C2273723C499");

            entity.ToTable("tb_Books");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsBestSeller).HasDefaultValue(false);
            entity.Property(e => e.IsNew).HasDefaultValue(true);
            entity.Property(e => e.IsStar).HasDefaultValue(0);
            entity.Property(e => e.NameAuthor).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.TbBooks)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__tb_Books__Author__656C112C");

            entity.HasOne(d => d.Category).WithMany(p => p.TbBooks)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__tb_Books__Catego__66603565");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tb_Categ__19093A2BC70E034C");

            entity.ToTable("tb_Categories");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__tb_Menus__C99ED250F0EADCCE");

            entity.ToTable("tb_Menus");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MenuName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParentMenuId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ParentMenuID");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.InverseParentMenu)
                .HasForeignKey(d => d.ParentMenuId)
                .HasConstraintName("FK__tb_Menus__Parent__7C4F7684");
        });

        modelBuilder.Entity<TbReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__tb_Revie__74BC79AEAE4B8BA5");

            entity.ToTable("tb_Reviews");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Book).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__tb_Review__BookI__6EF57B66");

            entity.HasOne(d => d.User).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tb_Review__UserI__6FE99F9F");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tb_Users__1788CCAC90D1F71B");

            entity.ToTable("tb_Users");

            entity.HasIndex(e => e.Email, "UQ__tb_Users__A9D10534DF0D6972").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbUserActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__tb_UserA__45F4A7F1271FCE6C");

            entity.ToTable("tb_UserActivity");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ActivityDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TbUserActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tb_UserAc__UserI__01142BA1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
