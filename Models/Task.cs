using System;
using System.Collections.Generic;
using System.Linq;


namespace OrganizingApp.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string? TaskDesc { get; set; }
        public string? Notes { get; set; }
        public string? IsCompleted { get; set; }

        public int LocationId { get; set; }
    }
}