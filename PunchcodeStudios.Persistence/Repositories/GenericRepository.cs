using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Domain.Common;
using PunchcodeStudios.Persistence.DatabaseContext;

namespace PunchcodeStudios.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly PCStudioDbContext _context;

        public GenericRepository(PCStudioDbContext context)
        {
            this._context = context;
        }
        public async Task<IReadOnlyList<T>> GetAsync(bool includeDeleted = false)
        {
            IReadOnlyList<T> list = await _context.Set<T>().AsNoTracking().ToListAsync();
            return includeDeleted 
                ? list 
                : list.Where(q => q.DateDeleted == null).ToList();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
