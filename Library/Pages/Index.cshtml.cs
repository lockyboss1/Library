using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserContext _context;

        public IndexModel(UserContext context)
        {
            _context = context;
        }

        public new List<Users> User { get; set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Users User = await
            _context.User.FindAsync(id);

            if (User!= null)
            {
                _context.User.Remove(User);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }     
    }
}
