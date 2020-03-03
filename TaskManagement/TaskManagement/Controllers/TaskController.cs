using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;
using TaskManagement.Services.Contracts;
using TaskManagement.Web.Mappers.Contracts;
using TaskManagement.Web.Models;

namespace TaskManagement.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IMapper<TaskViewModel, Entities.Task> taskMapper;
        private readonly ITaskService taskService;
        private readonly IUserService userService;
        public TaskController(IMapper<TaskViewModel, Entities.Task> taskMapper, ITaskService taskService, IUserService userService)
        {
            this.taskMapper = taskMapper;
            this.taskService = taskService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await this.taskService.GetAllAsync();

            var TaskViewModel = new List<TaskViewModel>();
            foreach (var task in tasks)
            {
                TaskViewModel.Add(this.taskMapper.Map(task));
            }

            return View(TaskViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create()
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var allUsers = this.userService.GetAllUsersAsync();
            var taskViewModel = new TaskViewModel();
            taskViewModel.AllUsers = await allUsers;
            return View(taskViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskViewModel taskViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.taskService.CreateTask(taskViewModel.TaskName, taskViewModel.Description, userId, taskViewModel.DueTime, taskViewModel.TypeTask, taskViewModel.AllUsers, taskViewModel.NextActionDate);

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var users = await this.userService.GetAllUsersForTaskAsync(id);
            var task = await this.taskService.FindTaskById(id);
            var taskViewModel = this.taskMapper.Map(task);
            taskViewModel.AllUsers = users;
            return View(taskViewModel);
        }

        [HttpPost]
        [Authorize(Roles= "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskViewModel taskViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var allUsers = await this.userService.GetAllUsersForTaskAsync(taskViewModel.Id);
            await this.taskService.EditTask(taskViewModel.Id, taskViewModel.TaskName, taskViewModel.Description,taskViewModel.DueTime, taskViewModel.StatusTask,allUsers);

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Entities.Task task = await this.taskService.FindTaskById(id);
            TaskViewModel taskViewModel = this.taskMapper.Map(task);
            var allUsers = await this.userService.GetSelectedUsersAsync(id);
            taskViewModel.AllUsers = allUsers;
            return View(taskViewModel);
        }
    }
}