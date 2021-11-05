namespace DynamicDashboards.Client.Features;

public class ComponentModel
{
    public ComponentModel(string? title, string? typeString, int id)
    {
        Title = title;
        TypeString = typeString;
        Id = id;
    }

    public string? Title { get; }
    public string? TypeString { get; }
    public Type? ResolvedType => TryResolveType(TypeString);
    public int Id { get; set; }

    private Type? TryResolveType(string? typeString)
    {
        return Type.GetType($"{typeString}");
    }
}