using DynamicDashboards.Server.Domain;
using DynamicDashboards.Server.Features.Dashboards;
using DynamicDashboards.Shared;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=dashboard"));

builder.Services.AddScoped<DashboardQuery>();
builder.Services.AddScoped<AddPanelCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

await MigrateDB(app);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("api/dashboard", async ([FromServices] DashboardQuery query) => await query.Execute());
app.MapPut("api/dashboard/panel",
    async (HttpContext ctx, [FromBody] AddPanelCommand panel, [FromServices] AddPanelCommandHandler command) =>
    {
        var id = await command.Execute(panel);
        return Results.Created($"{ctx.Request.GetDisplayUrl()}/{id}", null);
    });

app.MapDelete("api/dashboard/{dashboardId}/panel/{panelId}",
    async ([FromServices] ApplicationDbContext dbContext, int dashboardId, int panelId) =>
    {
        var dashboard = await dbContext.Dashboards
            .Include(x => x.Panels)
            .FirstOrDefaultAsync(x => x.Id == dashboardId);

        if (dashboard == null) return Results.NotFound();

        dashboard.RemovePanel(panelId);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    });

app.MapFallbackToFile("index.html");

app.Run();

async Task MigrateDB(WebApplication webApplication)
{
    var scope = app
        .Services.GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
    
    await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

    if (context != null)
        await context.Database.MigrateAsync();
}