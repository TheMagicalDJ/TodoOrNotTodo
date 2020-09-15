using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoOrNotTodo.Models;

namespace TodoOrNotTodo.Data
{
    public class TodoTaskDBContext : DbContext
    {
        public TodoTaskDBContext(DbContextOptions options)
         :base(options)
        {
        }

        public DbSet<ToDoTask> Todos { get; set; }

    }
}
