using DenamicArrayProject;

var stringArray = new DynamicArray<string>();
stringArray.Add("Some String");
stringArray.Add(42.ToString());

foreach (var item in stringArray)
{
    Console.WriteLine(item);
}