namespace DynamicDashboards.Shared;

public class DashboardModel
{
    public IEnumerable<PanelModel> Panels { get; set; } = Enumerable.Empty<PanelModel>();
    public int Id { get; set; }
}

public class PanelModel
{
    public string? Title { get; set; }
    public string? ComponentType { get; set; }
    public int Id { get; set; }
}