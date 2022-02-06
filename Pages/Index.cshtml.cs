using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        public string SearchUsername { get; set; }
        [BindProperty]
        public string SearchPassword { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = from m in _context.User select m;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var dbEntry = _context.User.FirstOrDefault(acc => acc.UserName == SearchUsername);
            return RedirectToPage("/Users");
        }
    }
}
