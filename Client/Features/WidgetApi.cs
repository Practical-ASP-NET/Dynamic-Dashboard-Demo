using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace DynamicDashboards.Client.Features;

public class WidgetApi
{
    public class WidgetModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    
    public IEnumerable<WidgetModel?> ListAll()
    {
        var widgets = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.IsClass
                        && x.Namespace == "DynamicDashboards.Client.Features.Widgets"
                        && x.BaseType == typeof(ComponentBase));
        
        return widgets.Select(x => new WidgetModel{Name = x.Name, Type = x.FullName});
    }
}