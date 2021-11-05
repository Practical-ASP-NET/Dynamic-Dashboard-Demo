using DynamicDashboards.Server.Domain;
using DynamicDashboards.Server.Domain.Dashboards;
using DynamicDashboards.Shared;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboards.Server.Features.Dashboards;

public class AddPanelCommandHandler
{
    private readonly ApplicationDbContext _dbContext;

    public AddPanelCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Execute(AddPanelCommand command)
    {
        var dashboard = await _dbContext.Dashboards
            .Include(x=>x.Panels)
            .FirstOrDefaultAsync();
        if (dashboard == null)
        {
            dashboard = new Dashboard();
            _dbContext.Dashboards.Add(dashboard);
        }

        var panel = new Panel
        {
            Title = command.Title,
            ComponentType = command.Type
        };
        
        dashboard.Panels.Add(panel);
        await _dbContext.SaveChangesAsync();

        return panel.Id;
    }
}