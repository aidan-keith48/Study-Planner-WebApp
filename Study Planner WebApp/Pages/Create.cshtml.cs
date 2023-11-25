using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Study_Planner_WebApp.Auth;
using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Pages
{
    public class CreateModel : PageModel
    {
        HashingPassword hashPassword = new HashingPassword();

        private readonly Study_Planner_WebAppContext _context;

        public CreateModel(Study_Planner_WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterUser RegisterUser { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.RegisterUser == null || RegisterUser == null)
            {
                return Page();
            }

            string passWord = RegisterUser.password;
            string hashedPassWord = hashPassword.HashPassword(passWord);

            RegisterUser.password = hashedPassWord;


            _context.RegisterUser.Add(RegisterUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("LoginPage");
        }
    }
}
