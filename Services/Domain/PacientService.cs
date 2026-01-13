using Microsoft.EntityFrameworkCore;
using NIS.Data;
using NIS.Data.Models;
using NIS.Services.Crud;

namespace NIS.Services.Domain
{
    public sealed class PacientService(IDbContextFactory<NisDbContext> f) : CrudServiceBase<N_PACIENT>(f)
    {
        public async Task<bool> HasRelationsAsync(decimal id)
        {
            await using var db = await DbFactory.CreateDbContextAsync();
            return await db.N_VYSETRENIEs.AnyAsync(x => x.ID_PACIENTA == id)
                || await db.N_PRIJEMs.AnyAsync(x => x.ID_PACIENTA == id);
        }

        public override async Task DeleteAsync(object id)
        {
            var pid = (decimal)id;

            if (await HasRelationsAsync(pid))
                throw new InvalidOperationException("Pacient má väzby.");

            await base.DeleteAsync(id);
        }
    }
}