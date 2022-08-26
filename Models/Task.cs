using System;
using System.Collections.Generic;
using System.Linq;


namespace OrganizingApp.Models
{
    public class Task
    {
        public Task()
        {
        }

        public int taskId { get; set; }
        public string? taskDesc { get; set; }
        public string? notes { get; set; }
        public bool isCompleted { get; set; }

        public int locationId { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        
    }
}