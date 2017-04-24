using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Data.Models
{
    public class Repository<T> where T : class
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
        public void Insert(T entity)
        {
            _context.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Get all the entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        public void Update(T entity, bool saveChanges = true)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            SaveChanges(saveChanges);
        }

        /// <summary>
        /// Delete an entity based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saveChanges"></param>
        public void Delete(int id, bool saveChanges = true)
        {
            var entity = GetById(id);
            Delete(entity);
            SaveChanges(saveChanges);
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        public virtual void Delete(T entity, bool saveChanges = true)
        {
            if (_context.Entry(entity).State == EntityState.Deleted)
            {
                _context.Set<T>().Attach(entity);
            }
            _context.Set<T>().Remove(entity);
            SaveChanges(saveChanges);
        }

        /// <summary>
        /// Get the entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            if (id <= 0) { throw new System.Exception("Error: Id is missing"); }
            var entity = _context.Set<T>().Find(id);
            if (entity == null) { throw new System.Exception("Error: Entity not found"); }
            return entity;
        }

        /// <summary>
        /// Save changes to DB
        /// </summary>
        /// <param name="saveChanges"></param>
        public void SaveChanges(bool saveChanges = true)
        {
            if (saveChanges) _context.SaveChanges();
        }
    }
}
