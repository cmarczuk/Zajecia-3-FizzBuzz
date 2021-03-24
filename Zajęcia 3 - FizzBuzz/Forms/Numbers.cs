using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zajęcia_3___FizzBuzz.Forms
{
    public class Numbers
    {
        [Display(Name = "Liczba:")]
        [Required(ErrorMessage = "Podaj liczbę!")]
        [Range(1, 1000, ErrorMessage = "Podaj liczbę z zakresu 1-1000!")]
        public int Number { get; set; }

        public string Date { get; set; }

        public string Message { get; set; }
    }
}