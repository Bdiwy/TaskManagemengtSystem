using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentSystem.Srvices.Interfaces;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Controllers
{
    public class UserTaskController : Controller
    {    
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpPost]
        public IActionResult Add(int TaskListId, int WorkSpaceId)
        {
            var userTaskVM = new UserTaskAddViewModel
            {
                TaskListId = TaskListId,
                WorkSpaceId = WorkSpaceId
            };
            return View("Add",userTaskVM);
        }

        public async Task<IActionResult> SaveAdd(UserTaskAddViewModel userTaskFromRequest)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _userTaskService.CreateAsync(userTaskFromRequest, userId);
                if (result.Succeeded)
                {
                    return RedirectToAction("ShowAll", "TaskList", new { id = userTaskFromRequest.WorkSpaceId });
                }

                ModelState.AddModelError("", result.ErrorMessage ?? "Failed to create the task");
            }
            return View("Add", userTaskFromRequest);
        }

        public async Task<IActionResult>Edit(int Id, int WorkSpaceId)
        {
            var result = await _userTaskService.GetForEditAsync(Id, WorkSpaceId);
            if (result.Succeeded)
                return View("Edit", result.Data);

            return RedirectToAction("ShowAll", "TaskList", new { Id = WorkSpaceId });
        }

        public async Task<IActionResult> SaveEdit(UserTaskEditViewModel userTaskFromRequest)
        {
            if(ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _userTaskService.UpdateAsync(userTaskFromRequest, userId);
                if (result.Succeeded)
                    return RedirectToAction("ShowAll", "TaskList", new { Id = userTaskFromRequest.WorkSpaceId });

                ModelState.AddModelError("", result.ErrorMessage ?? "Failed to update the task");
            }
            return View("Edit", userTaskFromRequest);
        }

        public async Task<IActionResult> Delete(int id, int workSpaceId)
        {
            await _userTaskService.DeleteAsync(id);
            return RedirectToAction("ShowAll", "TaskList", new { Id = workSpaceId });
        }

        public async Task<IActionResult> IsDone(CheckIsDoneTaskViewModel taskIsDoneModel)
        {
            if (taskIsDoneModel is not null)
            {
                var result = await _userTaskService.SetIsDoneAsync(taskIsDoneModel);
                if (result.Succeeded)
                    return RedirectToAction("ShowAll", "TaskList", new { Id = taskIsDoneModel.WorkSpaceId});

                return NotFound();
            }
            return BadRequest();
        }
    }
}
