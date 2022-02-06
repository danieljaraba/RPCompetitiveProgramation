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
            var TotalUsers = from m in _context.User
                             select m;
            var user = TotalUsers;
            if (!string.IsNullOrEmpty(SearchUsername))
            {
                user = TotalUsers.Where(s => s.UserName.Equals(SearchUsername));
            }
            User = await user.ToListAsync();
            if (User.Count == 1)
            {
                if (User.ElementAt(0).Password.Equals(SearchPassword) && !string.IsNullOrEmpty(SearchPassword))
                {
                    ViewData["Message"] = User.ElementAt(0).UserName;
                    User = await TotalUsers.ToListAsync();
                }
                else
                {
                    Response.Redirect("/Users");
                }
            }
            else
            {
                Response.Redirect("/Index");
            }
        }
    }
}
