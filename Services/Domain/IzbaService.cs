using Microsoft.EntityFrameworkCore;
using NIS.Data;
using NIS.Data.Models;
using NIS.Services.Crud;

namespace NIS.Services.Domain;

public sealed class IzbaService(IDbContextFactory<NisDbContext> f) : CrudServiceBase<N_IZBA>(f)
{
}
