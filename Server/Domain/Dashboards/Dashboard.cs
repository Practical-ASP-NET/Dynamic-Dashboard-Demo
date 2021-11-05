namespace DynamicDashboards.Server.Domain.Dashboards;

public class Dashboard
{
    public int Id { get; set; }
    public List<Panel> Panels { get; set; } = new();

    public void RemovePanel(int panelId)
    {
        var existing = Panels.FirstOrDefault(x => x.Id == panelId);
        if (existing != null)
        {
            Panels.Remove(existing);
        }
    }
}

public class Panel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ComponentType { get; set; }
}