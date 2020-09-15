using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoOrNotTodo.Data;
using TodoOrNotTodo.Models;

namespace TodoOrNotTodo.Pages
{
    public class EditModel : PageModel
    {
        private readonly TodoTaskDBContext _context;
    
        public EditModel(TodoTaskDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoTask ToDoTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ToDoTask = await _context.Todos.FindAsync(id);

            if (ToDoTask == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer {ToDoTask.Id} not found!");
            }

            return RedirectToPage("./Index");
        }
    }
}
