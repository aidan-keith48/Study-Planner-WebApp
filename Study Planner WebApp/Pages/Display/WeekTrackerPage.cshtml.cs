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
    public class WeekTrackerPageModel : PageModel
    {
        private readonly Study_Planner_WebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        helperFunction helper = new helperFunction();
        dbController controller = new dbController();

        Dictionary<int, double> weekInfo = new Dictionary<int, double>();
        Dictionary<int, double> testInfo = new Dictionary<int, double>();
        List<RecordData> records = new List<RecordData>();

       // public Dictionary<int, double> weekInfo = new Dictionary<int, double>();

        public WeekTrackerPageModel(Study_Planner_WebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<Week_Tracking> Week_Tracking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RegisterUser loggedInStudent = _httpContextAccessor.HttpContext.Session.GetObject<RegisterUser>("LoggedInStudent");

            if (_context.Week_Tracking != null)
            {
                Week_Tracking = await _context.Week_Tracking.ToListAsync();
                helper.addWeeks("test user: admin", loggedInStudent.Id, weekInfo,testInfo);
                ViewData["LoggedInStudent"] = loggedInStudent;
            }
        }
    }
}
