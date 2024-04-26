using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Birthdays.Data;
using Birthdays.Models;

namespace Birthdays.Pages.CRUD
{
    public class DetailsModel : PageModel
    {
        private readonly Birthdays.Data.BirthdaysContext _context;

        public DetailsModel(Birthdays.Data.BirthdaysContext context)
        {
            _context = context;
        }

        public Birthday Birthday { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthday.FirstOrDefaultAsync(m => m.Id == id);
            if (birthday == null)
            {
                return NotFound();
            }
            else
            {
                Birthday = birthday;
            }
            return Page();
        }
    }
}
