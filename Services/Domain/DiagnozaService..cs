using Microsoft.EntityFrameworkCore;
using NIS.Data;
using NIS.Data.Models;
using NIS.Services.Crud;

namespace NIS.Services.Domain
{
    public sealed class DiagnozaService(IDbContextFactory<NisDbContext> f) : CrudServiceBase<N_DIAGNOZA>(f)
    {
    }
}