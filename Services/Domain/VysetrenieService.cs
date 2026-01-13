using Microsoft.EntityFrameworkCore;
using NIS.Data;
using NIS.Data.Models;
using NIS.Services.Crud;

namespace NIS.Services.Domain
{
    public sealed class VysetrenieService(IDbContextFactory<NisDbContext> f) : IReadOnlyService<N_VYSETRENIE>
    {
        private readonly IDbContextFactory<NisDbContext> _f = f;

        public async Task<List<N_VYSETRENIE>> GetAllAsync()
        {
            await using var db = await _f.CreateDbContextAsync();
            return await db.N_VYSETRENIEs.AsNoTracking().ToListAsync();
        }

        public async Task<N_VYSETRENIE?> GetByIdAsync(object id)
        {
            await using var db = await _f.CreateDbContextAsync();
            return await db.N_VYSETRENIEs.FindAsync(id);
        }

        public async Task CreateAsync(N_VYSETRENIE v)
        {
            await using var db = await _f.CreateDbContextAsync();
            db.N_VYSETRENIEs.Add(v);
            await db.SaveChangesAsync();
        }
    }
}