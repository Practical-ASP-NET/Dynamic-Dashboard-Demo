using DynamicDashboards.Server.Domain;
using DynamicDashboards.Shared;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboards.Server.Features.Dashboards;

public class DashboardQuery
{
    private readonly ApplicationDbContext _dbContext;

    public DashboardQuery(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DashboardModel> Execute()
    {
        var dashboard = await _dbContext.Dashboards
            .Include(x=>x.Panels)
            .FirstOrDefaultAsync();

        if (dashboard == null)
            return new DashboardModel();

        return new DashboardModel
        {
            Id = dashboard.Id,
            Panels = dashboard.Panels.Select(x => new PanelModel
            {
                Title = x.Title,
                ComponentType = x.ComponentType,
                Id = x.Id
            })
        };
    }
}

