using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tareas")]
    public class TasksController : ControllerBase
    {
        private IApplicationTasks _applicationTasks { get; }

        public TasksController(IApplicationTasks applicationTasks)
        {
            _applicationTasks = applicationTasks;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> Get()
        {
            return await _applicationTasks.GetAllTask();
        }

        [HttpGet("pendientes")] // api/tareas/pendientes
        public async Task<ActionResult<List<TaskDto>>> GetPendientes()
        {
            return await _applicationTasks.GetPendingsTask();
        }

        [HttpGet("terminadas")] // api/tareas/terminadas
        public async Task<ActionResult<List<TaskDto>>> GetTerminadas()
        {
            return await _applicationTasks.GetFinishesTask();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateTaskDto task)
        {
            await _applicationTasks.CreateTask(task);
            return Ok();
        }

        [HttpPut] 
        public async Task<ActionResult<TaskDto>> Put(UpdateTaskDto task)
        {
            var taskupd = await _applicationTasks.UpdateTask(task);
            if (taskupd is null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id:int}")] // api/tareas/id
        public async Task<ActionResult> Delete(int id)
        {
            var task = await _applicationTasks.DeleteTask(id);
            if (task is null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
