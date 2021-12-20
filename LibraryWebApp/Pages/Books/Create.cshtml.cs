using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryWebApp.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibraryWebApp.Models.LibraryDBContext _context;

        public CreateModel(LibraryWebApp.Models.LibraryDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AttributeId"] = new SelectList(_context.Attributes, "Id", "Color");
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName");
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Genre");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        [Required]
        public Category Category { get; set; }
        [Required]
        [BindProperty]
        public Author Author { get; set; }
        [Required]
        [BindProperty]
        public Models.Attribute Attribute { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Books.Add(Book);
            _context.SaveChangesAsync();

            return RedirectToPage("/Books/Index");
        }
        
    }
}
