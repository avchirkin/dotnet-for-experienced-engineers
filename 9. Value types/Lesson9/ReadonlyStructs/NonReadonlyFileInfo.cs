namespace ReadonlyStructs;

public struct NonReadonlyFileInfo
{
    public string? Path { get; set; }

    public string? Extension { get; set; }
    
    public DateTime LastUpdatedAt { get; set; }
    
    public int Size { get; set; }
}