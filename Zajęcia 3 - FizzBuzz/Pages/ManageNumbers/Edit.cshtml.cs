using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zajęcia_3___FizzBuzz.Data;
using Zajęcia_3___FizzBuzz.Forms;

namespace Zajęcia_4___DBFizzBuzz.Pages.ManageNumbers
{
    public class EditModel : PageModel
    {
        private readonly Zajęcia_3___FizzBuzz.Data.NumbersContext _context;

        public EditModel(Zajęcia_3___FizzBuzz.Data.NumbersContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Numbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumbersExists(Numbers.Id))
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

        private bool NumbersExists(int id)
        {
            return _context.Numbers.Any(e => e.Id == id);
        }
    }
}
