using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.DbController;
using Study_Planner_WebApp.HelperFunction;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Modules
{
    public class CreateModel : PageModel
    {
        private readonly Study_Planner_WebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        dbController controller = new dbController();
        helperFunction helper = new helperFunction();


        public Dictionary<int, double> weekInfo = new Dictionary<int, double>();

        public CreateModel(Study_Planner_WebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [BindProperty]
        public Module Module { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Module == null || Module == null)
            {
                return Page();
            }

            // Get the logged-in student
            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");

            if (loggedInStudent == null)
            {
                return Page();
            }
            else
            {
                ViewData["LoggedInStudent"] = loggedInStudent;

                Module.userID = loggedInStudent.Id;
                Module.StudyHours = calcStudyHours(Module.Credits, Module.SemesterWeeks, Module.ClassHours);

                _context.Module.Add(Module);
                controller.InsertWeekInformation(Module.userID, Module.ModuleCode, Module.SemesterWeeks, Module.StudyHours);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }


        public double calcStudyHours(int credit, int numWeeks, double hoursePerWeek)
        {
            double studyHours = 0;
            studyHours = (credit * 10 / numWeeks) - hoursePerWeek;
            return studyHours;
        }
    }
}
