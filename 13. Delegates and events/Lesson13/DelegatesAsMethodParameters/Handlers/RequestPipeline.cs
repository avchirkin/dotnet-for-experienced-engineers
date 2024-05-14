namespace DelegatesAsMethodParameters.Handlers;

internal sealed class RequestPipeline(IRequestHandler first) : IRequestPipeline
{
    public IRequestHandler First { get; } = first;

    public void Execute(IRequest request)
    {
        first.Handle(request);
        Console.WriteLine($"Result context: {request.Context}");
    }
}