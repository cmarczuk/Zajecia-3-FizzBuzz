using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zajęcia_3___FizzBuzz.Data;
using Zajęcia_3___FizzBuzz.Forms;

namespace Zajęcia_4___DBFizzBuzz.Pages.ManageNumbers
{
    public class DeleteModel : PageModel
    {
        private readonly Zajęcia_3___FizzBuzz.Data.NumbersContext _context;

        public DeleteModel(Zajęcia_3___FizzBuzz.Data.NumbersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Numbers Numbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Numbers = await _context.Numbers.FirstOrDefaultAsync(m => m.Id == id);

            if (Numbers == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Numbers = await _context.Numbers.FindAsync(id);

            if (Numbers != null)
            {
                _context.Numbers.Remove(Numbers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
