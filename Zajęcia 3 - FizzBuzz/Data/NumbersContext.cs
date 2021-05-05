using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajęcia_3___FizzBuzz.Forms;

namespace Zajęcia_3___FizzBuzz.Data
{
    public class NumbersContext : DbContext
    {
        public NumbersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Numbers> Numbers { get; set; }
    }
}