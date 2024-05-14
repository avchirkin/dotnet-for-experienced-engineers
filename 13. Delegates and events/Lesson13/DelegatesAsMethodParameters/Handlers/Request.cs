namespace DelegatesAsMethodParameters.Handlers;

public sealed record Request(Guid Id) : IRequest
{
    public string Context { get; set; } = string.Empty;
}