namespace ReadonlyStructs;

// При объявлении readonly-структур компилятор отслеживает, что все пё поля и свойства неизменяемы после инициапизации
public readonly struct FileInfo
{
    // private string _extension; // Ошибка - поля должны быть помечены как readonly
    
    // public string? IncorrectPath { get; set; } // Ошибка - нельзя объявлять сеттер в readonly-структуре
    
    public string? Path { get; init; }

    public string? Extension { get; init; }
    
    public DateTime LastUpdatedAt { get; init; }
    
    public int Size { get; init; }
}