namespace ExceptionsBasics;

public class CustomerValidationException(string criteria) : Exception("Customer can't access this content")
{
    public string Criteria { get; } = criteria;
}