using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Modules
{
    public class DeleteModel : PageModel
    {
        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;

        public DeleteModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Module Module { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Module == null)
            {
                return NotFound();
            }

            var module = await _context.Module.FirstOrDefaultAsync(m => m.Id == id);

            if (module == null)
            {
                return NotFound();
            }
            else 
            {
                Module = module;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Module == null)
            {
                return NotFound();
            }
            var module = await _context.Module.FindAsync(id);

            if (module != null)
            {
                Module = module;
                _context.Module.Remove(Module);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
