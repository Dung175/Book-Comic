using BookComic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookComic.Controllers
{
    public class AuthorsController : Controller
    {
        
        private readonly BookComicContext _context;
       
        public AuthorsController(BookComicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/author/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_context.TbAuthors.ToList().Count() == 0)
            {
                return NotFound();
            }
            var book = await _context.TbAuthors.Include(i => i.TbBooks).
                FirstOrDefaultAsync(m => m.AuthorId == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.author = _context.TbAuthors.Where(i => i.AuthorId == id && i.IsActive == true).ToList();
            return View(book);
        }

    }
}
