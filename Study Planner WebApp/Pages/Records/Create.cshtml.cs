using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Records
{
    public class CreateModel : PageModel
    {
        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;

        public CreateModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecordData RecordData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RecordData == null || RecordData == null)
            {
                return Page();
            }

            _context.RecordData.Add(RecordData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
