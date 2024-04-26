using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Birthdays.Data;
using Birthdays.Models;

namespace Birthdays.Pages.CRUD
{
    public class CreateModel : PageModel
    {
        private readonly Birthdays.Data.BirthdaysContext _context;

        public CreateModel(Birthdays.Data.BirthdaysContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Birthday Birthday { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Birthday.Add(Birthday);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
