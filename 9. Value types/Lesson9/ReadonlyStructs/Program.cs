using ReadonlyStructs;
using FileInfo = ReadonlyStructs.FileInfo;

var fileInfo = new FileInfo
{
    Path = "SomeFile", Extension = "txt", Size = 1456, LastUpdatedAt = DateTime.Now
};

// fileInfo.Extension = "md"; // Ошибка - у свойства нет сеттера
Console.WriteLine($"{fileInfo.Path}.{fileInfo.Extension}, {fileInfo.Size} bytes, updated at {fileInfo.LastUpdatedAt}");

// Безопасная работа с мутабельными структурами
// Мутабельные (изменяемые) структуры не следует использовать в коде без особой необходимости и понимания всех рисков.
// Тем не менее, при работе с внешними библиотеками порой можно встретить такие структуры.
var nonReadonlyFileInfo = new NonReadonlyFileInfo
{
    Path = "SomeFile", Extension = "txt", Size = 1456, LastUpdatedAt = DateTime.Now
};

SafelyUseNonReadonlyStruct(nonReadonlyFileInfo);

void SafelyUseNonReadonlyStruct(in NonReadonlyFileInfo nonSecureFileInfo)
{
    // nonSecureFileInfo.Extension = "md"; // Ошибка! Передаваемая структура не является изменяемой
    Console.WriteLine($"{nonSecureFileInfo.Path}.{nonSecureFileInfo.Extension}, {nonSecureFileInfo.Size} bytes, updated at {nonSecureFileInfo.LastUpdatedAt}");
}