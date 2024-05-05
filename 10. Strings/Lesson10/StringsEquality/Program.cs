var strOne = "test string";
var strTwo = strOne;
var strThree = "test " + "string";

Console.WriteLine(strOne == strTwo); // true - равенство ссылок
Console.WriteLine(strOne == strThree); // true - посимвольное равенство

strTwo += " changed";
ChangeString(strOne);

Console.WriteLine(strOne == strTwo); // ВОПРОС - что выведется в консоль?

void ChangeString(string sourceString)
{
    sourceString += " changed";
}

var strFour = "str";
var strFive = "\nstr";
var strSix = "\nstr";

Console.WriteLine(strFour == strFive); // false
Console.WriteLine(strFour.Equals(strFive, StringComparison.Ordinal)); // false
Console.WriteLine(string.Compare(strFour, strFive, StringComparison.OrdinalIgnoreCase) == 0); // false
Console.WriteLine(strFour.CompareTo(strFive) == 0); // false

Console.WriteLine(strFive == strSix); // true
Console.WriteLine(strFive.Equals(strSix, StringComparison.Ordinal)); // true
Console.WriteLine(string.Compare(strFive, strSix, StringComparison.OrdinalIgnoreCase) == 0); // true
Console.WriteLine(strFive.CompareTo(strSix) == 0); // true