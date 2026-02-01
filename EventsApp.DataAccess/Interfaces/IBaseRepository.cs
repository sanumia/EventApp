using EventsApp.Domain.Entities;


namespace EventsApp.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken=default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken=default);
        Task<TEntity> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
