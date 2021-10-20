using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Models;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseModel
    {
        protected readonly InstagramContext _context;
        public GenericRepository(InstagramContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Edit(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _context.Set<T>().Where(x => !x.isDeleted);
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(e=>e.Id == id);
        }

        public async Task Remove(int id)
        {
            var entity = await GetById(id);
            
            entity.isDeleted = true;
            
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
