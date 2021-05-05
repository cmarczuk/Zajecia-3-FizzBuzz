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
    public class DetailsModel : PageModel
    {
        private readonly Zajęcia_3___FizzBuzz.Data.NumbersContext _context;

        public DetailsModel(Zajęcia_3___FizzBuzz.Data.NumbersContext context)
        {
            _context = context;
        }

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
    }
}
