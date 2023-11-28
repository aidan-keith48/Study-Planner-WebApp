using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Study_Planner_WebApp.DbController;
using Study_Planner_WebApp.HelperFunction;
using Study_Planner_WebApp.Migrations;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Modules
{
    public class IndexModel : PageModel
    {
        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        helperFunction helper = new helperFunction();
        dbController controller = new dbController();

        public Dictionary<int, double> weekInfo = new Dictionary<int, double>();

        public IndexModel(Data.Study_Planner_WebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<Module> Module { get; set; } = default!;

       

        public async Task<IActionResult> OnGetAsync()
        {   

            //Module studentModule = _httpContextAccessor.HttpContext.Session.GetObject<Module>("CurrentModule");

            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");           

            if (_context.Module != null)
            {
                Module = await _context.Module.ToListAsync();
                ViewData["LoggedInStudent"] = loggedInStudent;                
            }
           
            return Page();
        }

        //
    }
}
