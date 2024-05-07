// 1. Инициализация
var stack = new Stack<int>();

// 2. Работа со стеком

// Помещение элемента в очередь
stack.Push(25);
stack.Push(64);
stack.Push(37);
PrintStack();

// Чтение элемента с головы стека (без извлечения)
var next = stack.Peek();
Console.WriteLine(next); // 37
Console.WriteLine(stack.Count); // 3 - количество элементов не изменилось

// Извлечение элемента из головы очереди
var item = stack.Pop();
Console.WriteLine(item); // 37
Console.WriteLine(stack.Count); // 2 - количество элементов уменьшилось до 2

// Для безопасного извлечения элементов из очереди следует использовать Try-семантику
if (stack.TryPeek(out _))
{
    next = stack.Pop();
    // ... логика по обработке элемента
}

// или 
if (stack.TryPop(out next))
{
    // ... логика по обработке элемента
}

void PrintStack()
{
    foreach (var sItem in stack)
    {
        Console.Write(sItem + " ");
    }
    Console.WriteLine();
}

// Complexity (average)
// Push - O(1)
// Contains - O(n)
// Pop - O(1)