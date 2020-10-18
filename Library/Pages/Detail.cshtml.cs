using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Library.Pages
{
    public class DetailModel : PageModel
    {
        private readonly UserContext _context;

        public DetailModel(UserContext context)
        {
            _context = context;
        }

        public new Users User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.User.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            return Page();
        }
    }
}
