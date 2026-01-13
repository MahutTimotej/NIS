using Microsoft.EntityFrameworkCore;
using NIS.Data;
using NIS.Data.Models;
using NIS.Services.Crud;

namespace NIS.Services.Domain;

public sealed class LekarService(IDbContextFactory<NisDbContext> f) : CrudServiceBase<N_LEKAR>(f)
{
}
