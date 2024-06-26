namespace EnumsAndFlags;

/* В перечислениях каждому элементу соответствует целочисленное значение (по умолчанию - типа int). Значение стоит указывать явно,
 чтобы в будущем не возникло проблем при случайном добавлении нового элемента не в конец перечисления (с поломкой нумерации).
 Как правило, перечисления применяются для исчислимого небольшого множества связанных по смыслу элементов.
*/
public enum DayOfWeek
{
    Monday    = 1,
    Tuesday   = 2,
    Wednesday = 3,
    Thursday  = 4,
    Friday    = 5,
    Saturday  = 6,
    Sunday    = 7
}

// Если численное значение должно быть отличным от int, можно задать его через двоеточие (подобно синтаксису наследования)
public enum Axes : ushort
{
    X = 0,
    Y = 1,
    Z = 2
}