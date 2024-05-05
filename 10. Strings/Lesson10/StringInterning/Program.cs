var str1 = "test string";
var str2 = "test string";
var str3 = "test " + "string";
var str4 = string.Format("test {0}", "string");
var str5 = $"{str3}";
var str6 = GetFullString();
var str7 = "test " + GetShortString();

Console.WriteLine("Checking refs equality:");

Console.WriteLine("str1 = str2: " + ReferenceEquals(str1, str2)); // ?
Console.WriteLine("str1 = str3: " + ReferenceEquals(str1, str3)); // ?
Console.WriteLine("str1 = str4: " + ReferenceEquals(str1, str4)); // ?
Console.WriteLine("str1 = str5: " + ReferenceEquals(str1, str5)); // ?
Console.WriteLine("str1 = str6: " + ReferenceEquals(str1, str6)); // ?
Console.WriteLine("str1 = str7: " + ReferenceEquals(str1, str7)); // ?

// Console.ReadLine();
Console.WriteLine("Checking IsInterned:");

var interned1 = string.IsInterned(str1);
Console.WriteLine("interned1 = str1: " + ReferenceEquals(interned1, str1)); // ?

var interned2 = string.IsInterned(str2);
Console.WriteLine("interned1 = interned2: " + ReferenceEquals(interned1, interned2)); // ?

var interned4 = string.IsInterned(str4);
Console.WriteLine("interned1 = interned4: " + ReferenceEquals(interned1, interned4)); // ?
Console.WriteLine("str4 = interned4: " + ReferenceEquals(str4, interned4)); // ?

var forceInterned4 = string.Intern(str4);
Console.WriteLine("str4 = interned4: " + ReferenceEquals(str4, interned4)); // ?
Console.WriteLine("str4 = forceInterned4: " + ReferenceEquals(str4, forceInterned4)); // ?
Console.WriteLine("interned4 = forceInterned4: " + ReferenceEquals(interned4, forceInterned4)); // ?

string GetFullString()
{
    return "test string";
}

string GetShortString()
{
    return "string";
}