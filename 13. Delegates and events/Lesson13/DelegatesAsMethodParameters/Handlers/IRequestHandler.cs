namespace DelegatesAsMethodParameters.Handlers;

public interface IRequestHandler
{
    RequestDelegate? Next { get; }
    void Handle(IRequest request);
}

public delegate void RequestDelegate(IRequest request);