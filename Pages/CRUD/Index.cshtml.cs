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
    public class IndexModel : PageModel
    {
        private readonly Birthdays.Data.BirthdaysContext _context;

        public IndexModel(Birthdays.Data.BirthdaysContext context)
        {
            _context = context;
        }

        public IList<Birthday> Birthday { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Birthday = await _context.Birthday.ToListAsync();
        }
    }
}
