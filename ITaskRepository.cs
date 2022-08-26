using System;
using System.Collections.Generic;
using OrganizingApp.Models;
using System.Text;
using Task = OrganizingApp.Models.Task;

namespace OrganizingApp
{
    public interface ITaskRepository
    {
        public IEnumerable<Task> GetAllTasks();
        
        //below method will allow user to view one task at a time
        public Task GetTask(int id);

        public void UpdateTask(Task task);

        public void InsertTask(Task taskToInsert);

        public IEnumerable<Location> GetLocations();

        public Task AssignLocation();

        public void DeleteTask(Task task);
    }
}
