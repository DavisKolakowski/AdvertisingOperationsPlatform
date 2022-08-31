namespace AOP.WebAPI.Core.Repositories.Base
{
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Linq.Expressions;
    using System.Xml.Linq;

    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AOPDatabaseContext _dbContext;

        private DbSet<T> _dbSet;

        public RepositoryBase()
        {
            this._dbContext = new AOPDatabaseContext();
            this._dbSet = _dbContext.Set<T>();
        }

        public RepositoryBase(AOPDatabaseContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            var elements = this._dbSet;

            return elements;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            var element = this._dbSet.Where(expression);

            return element;
        }

        public void Create(T entity)
        {
            this._dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            this._dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }
    }
}
