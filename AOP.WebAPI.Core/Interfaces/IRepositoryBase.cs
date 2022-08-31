namespace AOP.WebAPI.Core.Interfaces
{
    using System.Linq.Expressions;
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
