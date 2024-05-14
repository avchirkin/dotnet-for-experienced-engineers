namespace DelegatesAsMethodParameters.Handlers;

public sealed record ContextEnricher(RequestDelegate? Next) : IRequestHandler
{
    public void Handle(IRequest request)
    {
        Console.WriteLine($"==={nameof(ContextEnricher)}===");
        
        request.Context = new Random().Next().ToString();
        Next?.Invoke(request);
    }
}