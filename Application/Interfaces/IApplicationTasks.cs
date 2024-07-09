using Application.DTO;

namespace Application.Interfaces
{
    public interface IApplicationTasks
    {
        public Task<TaskDto> CreateTask(CreateTaskDto task);
        public Task<List<TaskDto>> GetAllTask();
        public Task<List<TaskDto>> GetPendingsTask();
        public Task<List<TaskDto>> GetFinishesTask();
        public Task<TaskDto> UpdateTask(UpdateTaskDto task);
        public Task<TaskDto> DeleteTask(int id);
    }
}
