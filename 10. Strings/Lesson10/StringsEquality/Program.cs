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