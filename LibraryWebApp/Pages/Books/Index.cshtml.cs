using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Models;

namespace LibraryWebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryWebApp.Models.LibraryDBContext _context;

        public IndexModel(LibraryWebApp.Models.LibraryDBContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).ToListAsync();
        }
        public IActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).Where(b => b.Title.ToLower().Contains(SearchTerm.ToLower())).ToList();   
                return Page();
            }
            return RedirectToPage("/Books/Index");
        }
        public IActionResult OnPostByCategory()
        {
            Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).OrderBy(b => b.Category.Genre).ToList();   
            return Page();
           
        }
        public IActionResult OnPostByAuthor()
        {
            Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).
                OrderBy(b => b.Author.AuthorName).ToList();
            return Page();
        }
        public IActionResult OnPostByAttribute()
        {
            {
                Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).OrderBy(b => b.Attribute.Available).ToList();
            }
            return Page();
        }
        public IActionResult OnPostByTitle()
        {
            Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).OrderBy(b => b.Title).ToList();
            return Page();
        }
        public IActionResult OnPostByCategoryDes()
        {
            Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).OrderByDescending(b => b.Category.Genre).ToList();
            return Page();

        }
        public IActionResult OnPostByAuthorDes()
        {
            Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).
                OrderByDescending(b => b.Author.AuthorName).ToList();
            return Page();
        }
        public IActionResult OnPostByAttributeDes()
        {
            {
                Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).OrderByDescending(b => b.Attribute.Available).ToList();
            }
            return Page();
        }
        public IActionResult OnPostByTitleDes()
        {
            Book = _context.Books.
                 Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).OrderByDescending(b => b.Title).ToList();
            return Page();
        }
    }
}
