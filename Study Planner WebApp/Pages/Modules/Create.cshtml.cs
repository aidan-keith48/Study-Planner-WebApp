using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Modules
{
    public class CreateModel : PageModel
    {
        //private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;

        //public CreateModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context)
        //{
        //    _context = context;
        //}

        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Module == null || Module == null)
            {
                return Page();
            }

            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");

            ViewData["LoggedInStudent"] = loggedInStudent;


            Module.userID = loggedInStudent.Id;
            Module.StudyHours = calcStudyHours(Module.Credits, Module.SemesterWeeks, Module.ClassHours);

            _context.Module.Add(Module);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public double calcStudyHours(int credit, int numWeeks, double hoursePerWeek)
        {
            double studyHours = 0;
            studyHours = (credit * 10 / numWeeks) - hoursePerWeek;
            return studyHours;
        }
    }
}
