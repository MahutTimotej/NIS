using Microsoft.EntityFrameworkCore;
using NIS.Data;

namespace NIS.Services.Crud;

public abstract class CrudServiceBase<T>(IDbContextFactory<NisDbContext> dbFactory) : ICrudService<T>
    where T : class
{
    protected readonly IDbContextFactory<NisDbContext> DbFactory = dbFactory;

    public async Task<List<T>> GetAllAsync()
    {
        await using var db = await DbFactory.CreateDbContextAsync();
        return await db.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        await using var db = await DbFactory.CreateDbContextAsync();
        return await db.Set<T>().FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        await using var db = await DbFactory.CreateDbContextAsync();
        db.Set<T>().Add(entity);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        await using var db = await DbFactory.CreateDbContextAsync();
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(object id)
    {
        await using var db = await DbFactory.CreateDbContextAsync();
        var e = await db.Set<T>().FindAsync(id);
        if (e is null) return;

        db.Set<T>().Remove(e);
        await db.SaveChangesAsync();
    }
}
