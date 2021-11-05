using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace DynamicDashboards.Client.Features;

public class WidgetApi
{
    public IEnumerable<string?> ListAll()
    {
        var widgets = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.IsClass
                        && x.Namespace == "DynamicDashboards.Client.Features.Widgets"
                        && x.BaseType == typeof(ComponentBase));
        
        return widgets.Select(x => x.FullName);
    }
}