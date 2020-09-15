using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoOrNotTodo.Models;
using TodoOrNotTodo.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoOrNotTodo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoTaskDBContext _context;

        public IndexModel(TodoTaskDBContext context)
        {
            _context = context;
        }

        public IList<ToDoTask> ToDoTasks { get; set; }

        public async Task OnGetAsync()
        {
            ToDoTasks = await _context.Todos.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var toDoID = await _context.Todos.FindAsync(id);

            if (toDoID != null)
            {
                _context.Todos.Remove(toDoID);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
