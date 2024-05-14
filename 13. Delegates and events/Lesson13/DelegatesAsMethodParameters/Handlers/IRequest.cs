namespace DelegatesAsMethodParameters.Handlers;

public interface IRequest
{
    Guid Id { get; }
    string Context { get; set; }
}