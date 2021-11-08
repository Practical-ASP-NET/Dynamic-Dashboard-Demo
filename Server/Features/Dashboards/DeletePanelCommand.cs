using DynamicDashboards.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboards.Server.Features.Dashboards;

public class DeletePanelCommandHandler
{
    private readonly ApplicationDbContext _dbContext;

    public DeletePanelCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Execute(int dashboardId, int panelId)
    {
        var dashboard = await _dbContext.Dashboards
            .Include(x => x.Panels)
            .FirstOrDefaultAsync(x => x.Id == dashboardId);

        dashboard.RemovePanel(panelId);
        await _dbContext.SaveChangesAsync();
    }
}