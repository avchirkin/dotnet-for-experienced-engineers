using System.Globalization;

namespace DelegatesAsMethodParameters.Handlers;

public sealed record ContextLogger(RequestDelegate? Next) : IRequestHandler
{
    public void Handle(IRequest request)
    {
        Console.WriteLine($"==={nameof(ContextLogger)}===");
        
        var dt = DateTime.Now.ToString("u", CultureInfo.InvariantCulture);
        Console.WriteLine($"{dt}: {request}");
        Next?.Invoke(request);
    }
}