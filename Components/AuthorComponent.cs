using BookComic.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookComic.Components
{
    [ViewComponent(Name = "Author")]

    public class AuthorComponent : ViewComponent
    {
        private BookComicContext _context;

        public AuthorComponent(BookComicContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofAuthor = (from m in _context.TbAuthors
                                where (m.IsActive == true)
                                select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofAuthor));
        }
    }
}
