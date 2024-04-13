using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeCone.Ducks.Models;

namespace CodeCone.Ducks.Data
{
    public class CodeConeDucksContext : DbContext
    {
        public CodeConeDucksContext (DbContextOptions<CodeConeDucksContext> options)
            : base(options)
        {
        }

        public DbSet<CodeCone.Ducks.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<CodeCone.Ducks.Models.User> User { get; set; } = default!;
    }
}
