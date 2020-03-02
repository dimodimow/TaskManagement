using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services.Contracts;
using TaskManagement.Web.Mappers.Contracts;
using TaskManagement.Web.Models;

namespace TaskManagement.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IMapper<TaskViewModel, Entities.Task> taskMapper;
        private readonly ITaskService taskService;
        public TaskController(IMapper<TaskViewModel, Entities.Task> taskMapper, ITaskService taskService)
        {
            this.taskMapper = taskMapper;
            this.taskService = taskService;
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
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskViewModel taskViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.taskService.CreateTask(taskViewModel.TaskName, taskViewModel.Description, userId, taskViewModel.DueTime, taskViewModel.TypeTaskId, taskViewModel.SelectedUsers, taskViewModel.NextActionDate);

            return RedirectToAction("Index", "Home");
        }
    }
}