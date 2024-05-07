// 1. Инициализация
var set = new HashSet<int>();
set.Add(12);
set.Add(56);
set.Add(89);
set.Add(12);
PrintSet();

// Упрощённая инициализация
set = new HashSet<int>
{
    17, 85, 34, 2, 90, 34
};
PrintSet();

// Ещё более лаконичная форма инициализации
set = [4, 97, 23, 41, 15, 97];
PrintSet();

// 2. Операции с HashSet
var subset = new HashSet<int> { 4, 97 };
Console.WriteLine(subset.IsSubsetOf(set)); // true
Console.WriteLine(set.IsSupersetOf(subset)); // true

var overlappedSet = new HashSet<int> { 23, 99, 145};
Console.WriteLine(set.Overlaps(overlappedSet)); // true
Console.WriteLine(set.RemoveWhere(item => item == 4)); // 1
PrintSet();

void PrintSet()
{
    foreach (var item in set)
    {
        Console.WriteLine(item);
    }
}

// Complexity (average)
// Add - O(1), O(n) if collision
// Contains - O(1), O(n) if collision
// Remove - O(1), O(n) if collision