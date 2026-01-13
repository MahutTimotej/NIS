namespace NIS.Services.Crud
{
    public interface IReadOnlyService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
    }
}