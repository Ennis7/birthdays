using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Birthdays.Data;
using Birthdays.Models;

namespace Birthdays.Pages.CRUD
{
    public class EditModel : PageModel
    {
        private readonly Birthdays.Data.BirthdaysContext _context;

        public EditModel(Birthdays.Data.BirthdaysContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Birthday Birthday { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthday =  await _context.Birthday.FirstOrDefaultAsync(m => m.Id == id);
            if (birthday == null)
            {
                return NotFound();
            }
            Birthday = birthday;
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

            _context.Attach(Birthday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirthdayExists(Birthday.Id))
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

        private bool BirthdayExists(int id)
        {
            return _context.Birthday.Any(e => e.Id == id);
        }
    }
}
