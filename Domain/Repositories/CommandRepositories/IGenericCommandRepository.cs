namespace AcademyManager.Domain.Repositories.CommandRepositories
{
    public interface IGenericCommandRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}
