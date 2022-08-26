﻿using Microsoft.AspNetCore.Mvc;
using OrganizingApp;
using Task = OrganizingApp.Models.Task;

namespace OrganizingApp.Controllers
{
    //each method in this controller will correspond to a view that I've created
    public class TaskController : Controller
    {
        private readonly ITaskRepository repo;

        public TaskController(ITaskRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        //this Index method corresponds to the Index view I created
        //this method will return the Index View page with the appropriate Model data (IEnumerable<Tasks>)
        //the controller facilitates handling a request and handing it to the correct view and model
        public IActionResult Index()
        {
            var tasks = repo.GetAllTasks(); 

            return View(tasks);
        }

        public IActionResult ViewTask(int id)
        {
            var task = repo.GetTask(id);

            return View(task);
            //since we are passing in task as an argument in this View method...
            //that will serve as the Model we will work with in our ViewTask.cshtml View 
        }

        public IActionResult UpdateTask(int id)
        {
            Task task = repo.GetTask(id);

            if (task == null)
            {
                return View("TaskNotFound");
            }

            return View(task);
        }

        public IActionResult UpdateTaskToDatabase(Task task) //takes a task to be updated
        {
            repo.UpdateTask(task); //updates the task in the database

            return RedirectToAction("ViewTask", new { id = task.TaskId });
        }

        public IActionResult InsertTask()
        {
            var task = repo.AssignLocation();

            return View(task);
        }

        public IActionResult InsertTaskToDatabase(Task taskToInsert)
        {
            repo.InsertTask(taskToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(Task task)
        {
            repo.DeleteTask(task);
            return RedirectToAction("Index");
        }
    }
}