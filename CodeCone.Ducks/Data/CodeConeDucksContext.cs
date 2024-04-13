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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
      => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Support;Integrated Security=True;Multiple Active Result Sets=True;Trust Server Certificate=True;Command Timeout=300");
    }
}
