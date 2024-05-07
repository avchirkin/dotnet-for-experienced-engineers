var linkedList = new LinkedList<int>();
var first = linkedList.AddFirst(1);
var second = linkedList.AddAfter(first, 2);

Console.WriteLine(linkedList.First?.Value); // 1
Console.WriteLine(linkedList.First == first); // true

Console.WriteLine(linkedList.Last?.Value); // 2
Console.WriteLine(linkedList.Last == second); // true

var third = linkedList.AddLast(3);
Console.WriteLine(linkedList.Last?.Value); // 3
Console.WriteLine(linkedList.Last == second); // false
Console.WriteLine(linkedList.Last == third); // true

var zero = linkedList.AddBefore(first, 0);

Console.WriteLine(linkedList.First?.Value); // 0
Console.WriteLine(linkedList.First == first); // false
Console.WriteLine(linkedList.First == zero); // true

// linkedList.AddAfter(third, zero); // Ошибка!  The LinkedList node already belongs to a LinkedList

// Complexity (average)
// Add - O(1)
// Contains - O(n)
// Remove - O(n), RemoveFirst and RemoveLast - O(1)