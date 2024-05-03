namespace ValueTypesInheritance;

public struct Transaction :
    // EntityWithId // Ошибка - ожидается тип интерфейса!
    IHasId // ОК - наследовать интерфейс (или нескольких) можно
{
    public Guid Id { get; set; }
    
    public Guid FromAccount { get; set; }
    public Guid ToAccount { get; set; }
    public DateTime OperationDateTime { get; set; }
    public decimal OperationSum { get; set; }

    // Структуры могут содержать методы. VMT для структур НЕ существует, так как наследование в value types запрещено
    public void ValidateTransaction()
    {
        if (FromAccount == ToAccount)
        {
            throw new InvalidOperationException("Счёт списания и счёт зачисления не могут быть одним счётом");
        }
    }
}