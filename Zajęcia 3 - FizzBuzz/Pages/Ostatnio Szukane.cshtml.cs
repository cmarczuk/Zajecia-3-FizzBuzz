using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zajęcia_3___FizzBuzz.Forms;
using Zajęcia_3___FizzBuzz.Data;
using Microsoft.Extensions.Logging;

namespace Zajęcia_4___DBFizzBuzz.Pages
{
    public class Ostatnio_SzukaneModel : PageModel
    {
        private readonly NumbersContext _context;
        public IList<Numbers> Numbers { get; set; }

        public Ostatnio_SzukaneModel(NumbersContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var NumbersQuery = (from Numbers in
                    _context.Numbers
                                orderby Numbers.Date descending
                                select Numbers).Take(10);
            Numbers = NumbersQuery.ToList();
        }
    }
}