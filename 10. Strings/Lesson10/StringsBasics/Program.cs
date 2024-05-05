/* System.String (string) представляет из себя ссылочный класс, в рамках которого реализуется работа с символьной текстовой
 информацией. "Под капотом" у каждого экземпляра string лежит массив символов (char[]), составляющих строку.
 Строки неизменяемы. При попытке изменить строку (например, с помощью конкатенации) создается новая строка, а исходный
 экземпляр строки остаётся неизменным.
 */

// 1. Создание строк

using System.Globalization;

var strOne = "string 1";
Console.WriteLine(strOne); // string 1

var charArray = new[] { 's', 't', 'r', 'i', 'n', 'g', ' ', '2' };
var strTwo = new string(charArray);
Console.WriteLine(strTwo); // string 2

var strThree = "string" + " " + "3"; // конкатенация строк - приводит к созданию новой строки
Console.WriteLine(strThree); // string 3

var four = 4;
var strFour = $"string {four}"; // интерполяция строк - приводит к созданию новой строки и упаковке int-значения
Console.WriteLine(strFour); // string 4

var strNow = DateTime.Now.ToString("D"); // Метод ToString есть во всех типах, включая System.Object
Console.WriteLine(strNow); // Saturday, 4 May 2024

// 2. Работа со строками

// string наследует IEnumerable<char>, поэтому мы можем получить из неё IEnumerator и обойти, как обычную коллекцию
foreach (var ch in "example")
{ 
    Console.Write(ch);
}

Console.WriteLine();

// Изменение регистра символов
var hello = "Hello";
var upper = hello.ToUpper();
Console.WriteLine(upper); // HELLO

var lower = hello.ToLower();
Console.WriteLine(lower); // hello

// ToXXX vs ToXXXInvariant
var weird = "iii";
Console.WriteLine(weird.ToUpper()); // III
Console.WriteLine(weird.ToUpper(CultureInfo.CurrentCulture)); // III

Console.WriteLine(weird.ToUpper(CultureInfo.GetCultureInfo("tr-TR"))); // İİİ

Console.WriteLine(weird.ToUpper(CultureInfo.InvariantCulture)); // III
Console.WriteLine(weird.ToUpperInvariant()); // III

// Поиск и подстроки
var thesis = ".NET Course For The Dummies";

var searchPosition = thesis.IndexOf("Dummies", StringComparison.InvariantCulture);
var firstPart = thesis.Substring(0, searchPosition - 1);
var updatedThesis = $"{firstPart} Experienced Engineers";

Console.WriteLine(updatedThesis); // .NET Course For The Experienced Engineers

// Получение подстрок с помощью range-синтаксиса
var simpleString = "It's pretty simple";

var firstFive = simpleString[..5];
Console.WriteLine(firstFive); // It's 

var lastOnes = simpleString[5..];
Console.WriteLine(lastOnes); // pretty simple

var middle = simpleString[5..11];
Console.WriteLine(middle); // pretty

var fifthFromTheBeginning = simpleString[5];
Console.WriteLine(fifthFromTheBeginning); // p

var fifthFromTheEnd = simpleString[^5];
Console.WriteLine(fifthFromTheEnd); // i

var fromFifthToFifthFromTheEnd = simpleString[5..^5];
Console.WriteLine(fromFifthToFifthFromTheEnd); // pretty s

// 3. Специальные символы
var strWithNewLine = "\nEvery\nword\nfrom\nnew\nline";
Console.WriteLine(strWithNewLine);

var strWithTabulation = "\tTabulated string";
Console.WriteLine(strWithTabulation);

var stringAsIs = @"\tNon-tabulated string";
Console.WriteLine(stringAsIs);

var escapedQuotas = "I had a \"beautiful\" day yesterday";
Console.WriteLine(escapedQuotas);

var escapedQuotasTwo = @"I had a ""beautiful"" day yesterday";
Console.WriteLine(escapedQuotasTwo);

