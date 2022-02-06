using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPCompetitiveProgramation.Data;
using RPCompetitiveProgramation.Models;

namespace RPCompetitiveProgramation.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RPCompetitiveProgramation.Data.RPCompetitiveProgramationContext _context;

        public IndexModel(RPCompetitiveProgramation.Data.RPCompetitiveProgramationContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        [BindProperty]
        public string SearchUsername { get; set; }
        [BindProperty]
        public string SearchPassword { get; set; }
        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }

        public async Task OnPostAsync()
        {
            
        }
    }
}
