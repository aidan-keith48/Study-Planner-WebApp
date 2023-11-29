using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.DbController;
using Study_Planner_WebApp.HelperFunction;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages.Display
{
    

    public class WeekInformationPageModel : PageModel
    {
        dbController controller = new dbController();
        helperFunction helper = new helperFunction();

        private readonly Study_Planner_WebApp.Data.Study_Planner_WebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WeekInformationPageModel(Study_Planner_WebApp.Data.Study_Planner_WebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<Week_Information> Week_Information { get;set; } = default!;


        public async Task OnGetAsync()
        {
            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");

            if (_context.Week_Information != null)
            {
                Week_Information = await _context.Week_Information.ToListAsync();
                helper.addWeeks("moduleStore", loggedInStudent.Id);
                ViewData["LoggedInStudent"] = loggedInStudent;
            }
        }
    }
}
