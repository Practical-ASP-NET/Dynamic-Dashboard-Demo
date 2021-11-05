using DynamicDashboards.Shared;
using Refit;

namespace DynamicDashboards.Client.Features;

public interface IDashboardApi
{
    [Get("/dashboard")]
    public Task<DashboardModel> GetDashboards();

    [Put("/dashboard/panel")]
    public Task AddPanel(AddPanelCommand command);

    [Delete("/dashboard/{dashboardId}/panel/{panelId}")]
    public Task DeletePanel(int dashboardId, int panelId);
}