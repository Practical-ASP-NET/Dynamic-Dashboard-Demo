using DynamicDashboards.Shared;
using Refit;

namespace DynamicDashboards.Client.Features;

public interface IDashboardApi
{
    [Get("/api/dashboard")]
    public Task<DashboardModel> GetDashboards();

    [Put("/api/dashboard/panel")]
    public Task AddPanel(AddPanelCommand command);

    [Delete("/api/dashboard/{dashboardId}/panel/{panelId}")]
    public Task DeletePanel(int dashboardId, int panelId);
}