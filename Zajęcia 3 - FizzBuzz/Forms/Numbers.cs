using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zajęcia_3___FizzBuzz.Forms
{
    public class Numbers
    {
        public int Id { get; set; }

        [Display(Name = "Liczba:")]
        [Required(ErrorMessage = "Podaj liczbę!")]
        [Range(1, 1000, ErrorMessage = "Podaj liczbę z zakresu 1-1000!")]
        public int Number { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string Message { get; set; }
    }
}