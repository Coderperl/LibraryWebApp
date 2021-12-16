using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Models;

namespace LibraryWebApp.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly LibraryWebApp.Models.LibraryDBContext _context;

        public EditModel(LibraryWebApp.Models.LibraryDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        public Category Category { get; set; }
        public Author Author { get; set; }
        public Models.Attribute Attribute { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Attribute)
                .Include(b => b.Author)
                .Include(b => b.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
           ViewData["AttributeId"] = new SelectList(_context.Attributes, "Id", "Color");
           ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName");
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Genre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
