using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoOrNotTodo.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Task { get; set; }

        [BindProperty]
        public bool TaskComplete { get; set; }
    }
}
