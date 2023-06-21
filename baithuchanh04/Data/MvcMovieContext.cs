using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using baithuchanh04.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<baithuchanh04.Models.Student> Student { get; set; } = default!;

        public DbSet<baithuchanh04.Models.Faculty> Faculty { get; set; } = default!;

        public DbSet<baithuchanh04.Models.Employee> Employee { get; set; } = default!;

        public DbSet<baithuchanh04.Models.Customer> Customer { get; set; } = default!;
    }
}
