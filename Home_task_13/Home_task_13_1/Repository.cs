using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_13_1
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly RentalContext _dbContext;
        public readonly DbSet<T> _dbSet;

        public Repository(RentalContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }

    /*public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(RentalContext dbContext) : base(dbContext)
        {
        }

        public Category GetByIdWithEquipment(int id)
        {
            return _dbContext.Categories.Include(c => c.Equipment).FirstOrDefault(c => c.CategoryId == id);
        }
    }

    public class EquipmentRepository : Repository<Equipment>
    {
        public EquipmentRepository(RentalContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Equipment> GetAllWithCategoryAndBrand()
        {
            return _dbContext.Equipments.Include(e => e.Category).Include(e => e.Brand).ToList();
        }
    }*/
}
