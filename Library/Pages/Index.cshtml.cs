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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserContext _context;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(UserContext context)
        {
            _context = context;
        }

        public new List<Users> User { get; set; }

        //queries the database to search for user input
        //searches by name and author
        public async Task OnGetAsync()
        {
            var books = from b in _context.User
                        select b;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Name.ToLower().Contains(SearchString.ToLower()));
            }

            User = await books.ToListAsync();
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
