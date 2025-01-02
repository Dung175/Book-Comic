using BookComic.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookComic.Components
{
    [ViewComponent(Name = "MenuView")]

    public class MenuViewComponents:ViewComponent
    {
        private BookComicContext _context;
        public MenuViewComponents(BookComicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmenu = (from m in _context.TbMenus
                            where (m.IsActive == true)
                            select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listmenu));
        }

    }
}
