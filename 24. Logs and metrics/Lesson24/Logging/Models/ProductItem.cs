using System.Text.Json;

namespace Logging.Models;

public sealed record ProductItem(int Id, string Name)
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}