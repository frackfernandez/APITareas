using Repository.Entidades;

namespace Repository.Interfaces
{
    public interface IRepositoryTasks
    {
        public Task<TaskEntity> Create(TaskEntity entity);
        public Task<List<TaskEntity>> GetAll();
        public Task<List<TaskEntity>> GetPendings();
        public Task<List<TaskEntity>> GetFinishes();
        public Task<TaskEntity> Update(TaskEntity entity);
        public Task<TaskEntity> Delete(int id);
        public Task<bool> Exists(int id); 
    }
}
