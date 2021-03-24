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

namespace Zajęcia_3___FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Numbers> NumbersList { get; set; }

        [BindProperty]
        public Numbers Numbers { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionNumbersList = HttpContext.Session.GetString("SessionNumberList");
                if (SessionNumbersList != null)
                {
                    NumbersList = JsonConvert.DeserializeObject<List<Numbers>>(SessionNumbersList);
                }
                else NumbersList = new List<Numbers>();
                if (Numbers.Number % 3 == 0)
                {
                    Message += "Fizz";
                }
                if (Numbers.Number % 5 == 0)
                {
                    Message += "Buzz";
                }
                if (Message == null)
                {
                    Message += $"Liczba: { Numbers.Number} nie spełnia kryteriów Fizz / Buzz";
                }
                Numbers.Message = Message;
                Numbers.Date = DateTime.Now.ToString();
                NumbersList.Add(Numbers);
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