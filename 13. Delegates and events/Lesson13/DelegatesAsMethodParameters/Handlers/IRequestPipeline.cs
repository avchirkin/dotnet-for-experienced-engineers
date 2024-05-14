namespace DelegatesAsMethodParameters.Handlers;

public interface IRequestPipeline
{
    IRequestHandler First { get; }

    void Execute(IRequest request);
}