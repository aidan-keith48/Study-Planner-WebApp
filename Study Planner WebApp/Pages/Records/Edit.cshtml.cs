using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Records
{
    public class EditModel : PageModel
    {
        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;

        public EditModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context)
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

            var recorddata =  await _context.RecordData.FirstOrDefaultAsync(m => m.Id == id);
            if (recorddata == null)
            {
                return NotFound();
            }
            RecordData = recorddata;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RecordData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordDataExists(RecordData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecordDataExists(int id)
        {
          return (_context.RecordData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
