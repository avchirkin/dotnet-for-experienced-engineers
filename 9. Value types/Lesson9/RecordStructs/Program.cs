using RecordStructs;

/* record struct'ы определяют семантику, используемую в обычных записях, для структур, упрощая создание
 * лаконичных типов, обеспечивающих лучшую безопасность производительность в ряде случаев, нежели "обычные" записи,
 структуры или классы. К record struct'ам применимы все ограничения, имеющие место в работе с "обычными" структурами */

var productOne = new ProductItem("Sony Bravia", "Your Best Choice!");
var productTwo = new ProductItem("Sony Bravia", "Your Best Choice!");

// В record struct'ах операторы равенства и неравенства генерируются компилятором.
// Равными считаются структуры одного типа с одинаковым значением свойств и полей.
Console.WriteLine(productOne == productTwo); // true