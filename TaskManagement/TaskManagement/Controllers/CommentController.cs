using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Entities;
using TaskManagement.Services.Contracts;
using TaskManagement.Web.Mappers.Contracts;
using TaskManagement.Web.Models;

namespace TaskManagement.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMapper<CommentViewModel, Comment> commentMapper;
        public CommentController(ICommentService commentService, IMapper<CommentViewModel, Comment> commentMapper)
        {
            this.commentService = commentService;
            this.commentMapper = commentMapper;
        }
        public  IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateComment(Guid id)
        {
            var commentViewModel = new CommentViewModel();

            commentViewModel.TaskId = id;

            return View(commentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(CommentViewModel viewModel)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var newComment = await this.commentService.CreateComment(viewModel.Text, userId, viewModel.TaskId,viewModel.ReminderDate, viewModel.TypeCommentId);

                return RedirectToAction("Index", "Task");

            }
            catch (Exception)
            {
                return RedirectToAction("CreateComment", viewModel.Id);
            }
        }

        [HttpGet]
        public IActionResult SearchComment()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var allComments = await this.commentService.GetAllComments(id);

            var CommentViewModel = new List<CommentViewModel>();

            foreach (var comment in allComments)
            {
                CommentViewModel.Add(this.commentMapper.Map(comment));
            }
            return View(CommentViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var comment = await commentService.FindCommentById(id);
            var commentViewModel = new CommentViewModel();

            commentViewModel = commentMapper.Map(comment);
            
            return View(commentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CommentViewModel commentViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (commentViewModel.UserId != userId)
            {
                throw new ArgumentException("You cannot edit this comment, because it is created by somebody else. ");
            }
            await this.commentService.EditComment(commentViewModel.Id, commentViewModel.Text, userId, commentViewModel.TypeCommentId, commentViewModel.ReminderDate);

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.commentService.DeleteComment(Id);

            return RedirectToAction("Index", "Task");
        }

        [HttpPost]
        public async Task<IActionResult> Search(CommentViewModel commentViewModel)
        {
          var listComment  = await this.commentService.SearchAllComments(commentViewModel.TypeCommentId, commentViewModel.Text);
            var searchListViewModel = new SearchListCommentViewModel(listComment);
            return View(searchListViewModel);
        }
    }
}