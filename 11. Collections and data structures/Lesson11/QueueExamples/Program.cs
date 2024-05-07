// 1. Инициализация
var queue = new Queue<int>();

// 2. Работа с очередью

// Помещение элемента в очередь
queue.Enqueue(25);
queue.Enqueue(64);
queue.Enqueue(37);
PrintQueue();

// Чтение элемента из головы очереди (без извлечения)
var next = queue.Peek();
Console.WriteLine(next); // 25
Console.WriteLine(queue.Count); // 3 - количество элементов не изменилось

// Извлечение элемента из головы очереди
var item = queue.Dequeue();
Console.WriteLine(item); // 25
Console.WriteLine(queue.Count); // 2 - количество элементов уменьшилось до 2

// Для безопасного извлечения элементов из очереди следует использовать Try-семантику
if (queue.TryPeek(out _))
{
    next = queue.Dequeue();
    // ... логика по обработке элемента
}

// или 
if (queue.TryDequeue(out next))
{
    // ... логика по обработке элемента
}

void PrintQueue()
{
    foreach (var qItem in queue)
    {
        Console.Write(qItem + " ");
    }
    Console.WriteLine();
}

// Complexity (average)
// Enqueue - O(1)
// Contains - O(n)
// Dequeue - O(1)
