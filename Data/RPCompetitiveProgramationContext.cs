using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPCompetitiveProgramation.Models;

namespace RPCompetitiveProgramation.Data
{
    public class RPCompetitiveProgramationContext : DbContext
    {
        public RPCompetitiveProgramationContext (DbContextOptions<RPCompetitiveProgramationContext> options)
            : base(options)
        {
        }

        public DbSet<RPCompetitiveProgramation.Models.User> User { get; set; }
    }
}
