using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Records
{
    public class CreateModel : PageModel
    {
        private readonly Data.Study_Planner_WebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateModel(Data.Study_Planner_WebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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
            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");

            RecordData.studentId = loggedInStudent.Id;

            if (!ModelState.IsValid || _context.RecordData == null || RecordData == null)
            {
                return Page();
            }


            ViewData["LoggedInStudent"] = loggedInStudent;
            
            _context.RecordData.Add(RecordData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<Module> GetUserModules()
        {
            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");

            // Get the modules for the logged-in user
            var userModules = _context.Module.Where(m => m.userID == loggedInStudent.Id).ToList();

            return userModules;
        }
    }
}
