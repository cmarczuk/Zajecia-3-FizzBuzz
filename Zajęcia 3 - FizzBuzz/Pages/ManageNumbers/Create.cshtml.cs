using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zajęcia_3___FizzBuzz.Data;
using Zajęcia_3___FizzBuzz.Forms;

namespace Zajęcia_4___DBFizzBuzz.Pages.ManageNumbers
{
    public class CreateModel : PageModel
    {
        private readonly Zajęcia_3___FizzBuzz.Data.NumbersContext _context;

        public CreateModel(Zajęcia_3___FizzBuzz.Data.NumbersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Numbers Numbers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Numbers.Add(Numbers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
