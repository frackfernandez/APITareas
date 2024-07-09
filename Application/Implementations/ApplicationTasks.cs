using Application.DTO;
using Application.Interfaces;
using Repository.Entidades;
using Repository.Interfaces;

namespace Application.Implementations
{
    public class ApplicationTasks : IApplicationTasks
    {
        private IRepositoryTasks _repositoryTasks { get; }
        public ApplicationTasks(IRepositoryTasks repositoryTasks)
        {
            _repositoryTasks = repositoryTasks;
        }              

        public async Task<TaskDto> CreateTask(CreateTaskDto task)
        {
            var entity = new TaskEntity()
            {
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = "Pendiente"
            };           
            
            var entityCreated = await _repositoryTasks.Create(entity);
            var dto = new TaskDto()
            {
                Id = entityCreated.Id,
                Description = entityCreated.Description,
                StartDate = DateOnly.FromDateTime(entityCreated.StartDate),
                EndDate = DateOnly.FromDateTime(entityCreated.EndDate),
                Status = entityCreated.Status,
            };

            return dto;
        }

        public async Task<List<TaskDto>> GetAllTask()
        {           
            var list = new List<TaskDto>();

            var listEntidades = _repositoryTasks.GetAll().Result;

            foreach (var entity in listEntidades)
            {
                list.Add(new TaskDto()
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    StartDate = DateOnly.FromDateTime(entity.StartDate),
                    EndDate = DateOnly.FromDateTime(entity.EndDate),
                    Status = entity.Status,
                });
            }

            return list;
        }

        public async Task<List<TaskDto>> GetPendingsTask()
        {
            var list = new List<TaskDto>();

            var listEntidades = _repositoryTasks.GetPendings().Result;

            foreach (var entity in listEntidades)
            {
                list.Add(new TaskDto()
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    StartDate = DateOnly.FromDateTime(entity.StartDate),
                    EndDate = DateOnly.FromDateTime(entity.EndDate),
                    Status = entity.Status,
                });
            }

            return list;
        }

        public async Task<List<TaskDto>> GetFinishesTask()
        {
            var list = new List<TaskDto>();

            var listEntidades = _repositoryTasks.GetFinishes().Result;

            foreach (var entity in listEntidades)
            {
                list.Add(new TaskDto()
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    StartDate = DateOnly.FromDateTime(entity.StartDate),
                    EndDate = DateOnly.FromDateTime(entity.EndDate),
                    Status = entity.Status,
                });
            }

            return list;
        }

        public async Task<TaskDto> UpdateTask(UpdateTaskDto task)
        {
            var entity = new TaskEntity()
            {
                Id = task.Id,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = task.Status,
            };
            var exists = await _repositoryTasks.Exists(task.Id);
            if (!exists)
            {
                return null;
            }
            var entityCreated = await _repositoryTasks.Update(entity);
            var dto = new TaskDto()
            {
                Id = entityCreated.Id,
                Description = entityCreated.Description,
                StartDate = DateOnly.FromDateTime(entityCreated.StartDate),
                EndDate = DateOnly.FromDateTime(entityCreated.EndDate),
                Status = entityCreated.Status,
            };

            return dto;
        }

        public async Task<TaskDto> DeleteTask(int id)
        {
            var exists = await _repositoryTasks.Exists(id);
            if (!exists)
            {
                return null;
            }
            var task = await _repositoryTasks.Delete(id);
            return new TaskDto();
        }
    }
}
