using Microsoft.EntityFrameworkCore;
using NIS.Components;
using NIS.Data;
using NIS.Services;
using NIS.Services.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<NisDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

builder.Services.AddScoped<PacientService>();
builder.Services.AddScoped<LekarService>();
builder.Services.AddScoped<SestraService>();
builder.Services.AddScoped<DiagnozaService>();
builder.Services.AddScoped<IzbaService>();
builder.Services.AddScoped<VysetrenieService>();
builder.Services.AddScoped<NotificationService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapGet("/snimok/{id:decimal}", async (
    decimal id,
    NisDbContext db) =>
{
    var v = await db.N_VYSETRENIEs
        .AsNoTracking()
        .Where(x => x.ID_VYSETRENIA == id)
        .Select(x => new
        {
            x.SNIMOK,
            x.SNIMOK_MIME,
            x.SNIMOK_NAZOV
        })
        .FirstOrDefaultAsync();

    if (v?.SNIMOK == null)
        return Results.NotFound();

    return Results.File(
        v.SNIMOK,
        v.SNIMOK_MIME ?? "application/octet-stream",
        v.SNIMOK_NAZOV ?? "snimok.dcm"
    );
});

app.Run();
