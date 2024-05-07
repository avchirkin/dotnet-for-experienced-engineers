### 11. Коллекции и структуры данных
- generic-типы
- набор значений (HashSet<T>)
- список (List<T>)
- словарь (Dictionary<K,V>)
- связный список (LinkedList<T>)
- очередь (Queue<T>)
- стек (Stack<T>)

#### Практика
Написать класс-враппер для Dictionary, способный кешировать элементы на указанное время (TTL-cache). При добавлении
элемента в кеш или перезаписи по имеющемуся ключу TTL должен сбрасываться в исходное значение времени жизни элемента.
При истечении TTL при попытке получения данных из кеша по ключу враппер должен возвращать null.

#### Домашнее задание
1. Изучить [документацию](https://learn.microsoft.com/en-us/dotnet/standard/generics/) по generics (включая ссылки в таблице внизу страницы).
2. Изучить [статью](https://www.codeproject.com/Articles/500644/Understanding-Generic-Dictionary-in-depth) о внутреннем устройстве хэш-таблиц на примере Dictionary.
3. Изучить [статью](https://introprogramming.info/english-intro-csharp-book/read-online/chapter-19-data-structures-and-algorithm-complexity/) про algorithmic complexity разных структур данных и О-нотацию.
4. Изучить [таблицу](https://c-sharp-snippets.blogspot.com/2010/03/runtime-complexity-of-net-generic.html) complexity для разных коллекций .NET.
5. Реализовать класс CycledLinkedList, в котором можно зацикливать элементы (ссылаться из последнего на первый, из первого - на последний).
6. Написать класс-враппер для очереди, ограничивающий добавление в неё N элементами. В случае, если очередь переполнена
   и в неё пытаются добавить новый элемент, выбрасывать исключение.

