using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Pages
{
    public class EditModel : PageModel
    {
        private readonly UserContext _context;

        public EditModel(UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public new Users User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                User = new Users();
            }

            else
            {
                User = await _context.User.FindAsync(id);

                if (User == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == 0)
            {
                _context.User.Add(User);
            }
            else
            {
                _context.Attach(User).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
