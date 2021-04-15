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
    public class IndexModel : PageModel
    {
        private readonly Zajęcia_3___FizzBuzz.Data.NumbersContext _context;

        public IndexModel(Zajęcia_3___FizzBuzz.Data.NumbersContext context)
        {
            _context = context;
        }

        public IList<Numbers> Numbers { get;set; }

        public async Task OnGetAsync()
        {
            Numbers = await _context.Numbers.ToListAsync();
        }
    }
}
