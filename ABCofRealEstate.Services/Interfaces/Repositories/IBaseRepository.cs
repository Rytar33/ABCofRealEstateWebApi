using ABCofRealEstate.Data.Models.Entities;

namespace ABCofRealEstate.Services.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(Guid id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
}
