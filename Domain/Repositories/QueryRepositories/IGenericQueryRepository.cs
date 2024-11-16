namespace AcademyManager.Domain.Repositories.QueryRepositories
{
    public interface IGenericQueryRepository<T,TKey> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey Id);


    }
}
