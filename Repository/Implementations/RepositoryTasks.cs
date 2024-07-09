using Microsoft.EntityFrameworkCore;
using Repository.Entidades;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class RepositoryTasks : IRepositoryTasks
    {
        private ApplicationDbContext _context { get; }
        public RepositoryTasks(ApplicationDbContext context)
        {
            _context = context;
        }        

        public async Task<TaskEntity> Create(TaskEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TaskEntity>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<List<TaskEntity>> GetPendings()
        {
            return await _context.Tasks.Where(x => x.Status.ToLower() == "pendiente").ToListAsync();
        }

        public async Task<List<TaskEntity>> GetFinishes()
        {
            return await _context.Tasks.Where(x => x.Status.ToLower() == "terminada").ToListAsync();
        }

        public async Task<TaskEntity> Update(TaskEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskEntity> Delete(int id)
        {
            _context.Remove(new TaskEntity { Id = id });
            await _context.SaveChangesAsync();
            return new TaskEntity();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Tasks.AnyAsync(x => x.Id == id);
        }
    }
}
