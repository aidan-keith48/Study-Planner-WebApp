using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Study_Planner_WebApp.Auth;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginPageModel(AuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationService = authenticationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public RegisterUser user { get; set; }

        public Module userModules { get; set; }
        public void OnGet()
        {
        }


        public void OnPost()
        {
            var student = _authenticationService.Authentication(user.username, user.password);

            if (student != null)
            {
                HttpContext.Session.SetObject("LoggedInStudent", student);
                user.Id = student.Id;
                Response.Redirect("./Index");

            }
            else
            {
                // If the credentials are not correct, you might want to add a model error
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
        }

    }
}
