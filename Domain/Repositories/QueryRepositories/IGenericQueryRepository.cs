namespace AcademyManager.Domain.Repositories.QueryRepositories
{
    public interface IGenericQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);


    }
}
