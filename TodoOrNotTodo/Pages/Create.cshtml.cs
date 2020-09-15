using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoOrNotTodo.Data;
using TodoOrNotTodo.Models;


namespace TodoOrNotTodo.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TodoTaskDBContext _context;

        public CreateModel(TodoTaskDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoTask TodoTakeName { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todos.Add(TodoTakeName);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
