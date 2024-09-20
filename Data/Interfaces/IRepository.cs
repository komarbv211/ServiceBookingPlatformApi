
using Ardalis.Specification;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Save();
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetByID(object id);
        Task Insert(TEntity entity);
        Task Delete(object id);
        Task Delete(TEntity entityToDelete);
        Task Update(TEntity entity);
        Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification);
    }
}
