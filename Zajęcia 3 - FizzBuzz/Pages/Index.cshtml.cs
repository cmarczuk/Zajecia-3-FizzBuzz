using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajęcia_3___FizzBuzz.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zajęcia_3___FizzBuzz.Data;

namespace Zajęcia_3___FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NumbersContext _context;
        public List<Numbers> NumbersList { get; set; }

        [BindProperty]
        public Numbers Numbers { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, NumbersContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public string FizzBuzz(int liczba)
        {
            if (liczba % 3 == 0)
            {
                Message += "Fizz";
            }
            if (liczba % 5 == 0)
            {
                Message += "Buzz";
            }
            if (Message == null)
            {
                Message += $"Liczba: { Numbers.Number} nie spełnia kryteriów Fizz / Buzz";
            }
            return Message;
        }

        public List<Numbers> CheckList()
        {
            var SessionNumbersList = HttpContext.Session.GetString("SessionNumberList");
            if (SessionNumbersList != null)
            {
                NumbersList = JsonConvert.DeserializeObject<List<Numbers>>(SessionNumbersList);
            }
            else NumbersList = new List<Numbers>();
            return NumbersList;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                NumbersList = CheckList();
                Numbers.Message = FizzBuzz(Numbers.Number);
                Numbers.Date = DateTime.Now;
                NumbersList.Add(Numbers);
                _context.Numbers.Add(Numbers);
                _context.SaveChanges();
                HttpContext.Session.SetString("SessionNumberList", JsonConvert.SerializeObject(NumbersList));
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}