using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPCompetitiveProgramation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPCompetitiveProgramation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        RPCompetitiveProgramation.Data.RPCompetitiveProgramationContext _context;
        public IndexModel(ILogger<IndexModel> logger, RPCompetitiveProgramation.Data.RPCompetitiveProgramationContext? context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        [Required]
        public string SearchUsername { get; set; }
        [BindProperty]
        [Required]
        [DataType (DataType.Password)]
        public string SearchPassword { get; set; }

        public IList<User> User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var TotalUsers = from m in _context.User
                             select m;
            var user = TotalUsers;
            if (!string.IsNullOrEmpty(SearchUsername))
            {
                user = TotalUsers.Where(s => s.UserName.Equals(SearchUsername));
            }
            User = await user.ToListAsync();
            if (User.Count == 1 )
            {
                if (User.ElementAt(0).Password.Equals(SearchPassword) && !string.IsNullOrEmpty(SearchPassword))
                {
                    ViewData["Message"] = User.ElementAt(0).UserName;
                    User = await TotalUsers.ToListAsync();
                    Response.Redirect("Users/Index");
                }
                
            }
            return Page();
            //Return to index
        }
    }
}
