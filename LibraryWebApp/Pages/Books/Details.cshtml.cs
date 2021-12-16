using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryWebApp.Models.LibraryDBContext _context;

        public DetailsModel(LibraryWebApp.Models.LibraryDBContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        [BindProperty]
        [Required]
        public Category Category { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
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
            return Page();
        }
    }
}
