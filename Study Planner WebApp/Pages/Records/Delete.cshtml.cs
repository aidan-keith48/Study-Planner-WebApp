using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Records
{
    public class DeleteModel : PageModel
    {
        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;

        public DeleteModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RecordData RecordData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RecordData == null)
            {
                return NotFound();
            }

            var recorddata = await _context.RecordData.FirstOrDefaultAsync(m => m.Id == id);

            if (recorddata == null)
            {
                return NotFound();
            }
            else 
            {
                RecordData = recorddata;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RecordData == null)
            {
                return NotFound();
            }
            var recorddata = await _context.RecordData.FindAsync(id);

            if (recorddata != null)
            {
                RecordData = recorddata;
                _context.RecordData.Remove(RecordData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
