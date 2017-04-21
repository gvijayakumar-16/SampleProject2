using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Data.Models
{
    public abstract class Repository<T> where T : class
    {
        private readonly BloggingContext _context;
        public Repository(BloggingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert an entity
        /// </summary>
        /// <param name="entity"></param>
        protected void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all the entities
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        protected void Update(T entity, bool saveChanges = true)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            if (saveChanges) _context.SaveChanges();
        }
    }
}
