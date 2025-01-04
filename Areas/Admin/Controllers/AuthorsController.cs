using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookComic.Models;

namespace BookComic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : Controller
    {
        private readonly BookComicContext _context;

        public AuthorsController(BookComicContext context)
        {
            _context = context;
        }

        // GET: Admin/Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbAuthors.ToListAsync());
        }

        // GET: Admin/Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAuthor = await _context.TbAuthors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tbAuthor == null)
            {
                return NotFound();
            }

            return View(tbAuthor);
        }

        // GET: Admin/Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,Name,Title,Alias,Bio,ImageUrl,IsActive")] TbAuthor tbAuthor)
        {
            if (ModelState.IsValid)
            {
                tbAuthor.Alias = BookComic.Utilities.Functions.TitleSlugGenerator(tbAuthor.Title);
                _context.Add(tbAuthor);
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(tbAuthor);
        }

        // GET: Admin/Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAuthor = await _context.TbAuthors.FindAsync(id);
            if (tbAuthor == null)
            {
                return NotFound();
            }
            return View(tbAuthor);
        }

        // POST: Admin/Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,Name,Title,Alias,Bio,ImageUrl,IsActive")] TbAuthor tbAuthor)
        {
            if (id != tbAuthor.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbAuthorExists(tbAuthor.AuthorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbAuthor);
        }

        // GET: Admin/Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAuthor = await _context.TbAuthors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tbAuthor == null)
            {
                return NotFound();
            }

            return View(tbAuthor);
        }

        // POST: Admin/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbAuthor = await _context.TbAuthors.FindAsync(id);
            if (tbAuthor != null)
            {
                _context.TbAuthors.Remove(tbAuthor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbAuthorExists(int id)
        {
            return _context.TbAuthors.Any(e => e.AuthorId == id);
        }
    }
}
