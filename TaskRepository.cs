using Dapper;
using OrganizingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Task = OrganizingApp.Models.Task;

namespace OrganizingApp
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbConnection _conn;

        public TaskRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _conn.Query<Task>("SELECT * FROM TASK;");
        }

        public Task GetTask(int id)
        {
            return _conn.QuerySingle<Task>("SELECT * FROM TASK WHERE TASKID = @id", new { id = id });
        }

        public void UpdateTask(Task task)
        {
            _conn.Execute("UPDATE task SET taskDesc = @taskDesc, notes = @notes, isCompleted = @isCompleted WHERE taskId = @id",
                new { taskDesc = task.TaskDesc, notes = task.Notes, completed = task.IsCompleted });
            //parameterized to prevent SQL injection;
        }

        public void InsertTask(Task taskToInsert)
        {
            _conn.Execute("INSERT INTO task (TASKDESC, NOTES, ISCOMPLETED, LOCATIONID) VALUES (@taskDesc, @notes, @isCompleted, @locationId);",
                    new
                    {   taskDesc = taskToInsert.TaskDesc,
                        notes = taskToInsert.Notes,
                        isCompleted = taskToInsert.IsCompleted,
                        locationId = taskToInsert.LocationId
                    });
        }

        public IEnumerable<Location> GetLocations()
        {
            return _conn.Query<Location>("SELECT * FROM location;");
        }

        public Task AssignLocation()
        {
            var locationList = GetLocations();
            var task = new Task();
            task.Locations = locationList;

            return task;
        }

        public void DeleteTask(Task task)
        {
            _conn.Execute("DELETE FROM Task WHERE taskId = @id;",
                            new { id = task.TaskId });
        }
    }
}