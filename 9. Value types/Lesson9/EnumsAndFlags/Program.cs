using EnumsAndFlags;
using DayOfWeek = System.DayOfWeek;

// Перечисления

var friday = DayOfWeek.Friday;
Console.WriteLine((int)friday); // 5

var tuesdayStr = "Tuesday";
var tuesday = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), tuesdayStr);
Console.WriteLine(tuesday); // Tuesday


// Битовые флаги

var moveKeys = AllowedKeys.Letters | AllowedKeys.LShift;
Console.WriteLine(moveKeys.HasFlag(AllowedKeys.A)); // true
Console.WriteLine(moveKeys.HasFlag(AllowedKeys.LShift)); // true
Console.WriteLine(moveKeys.HasFlag(AllowedKeys.Ctrl)); // false
Console.WriteLine(moveKeys.HasFlag(AllowedKeys.Special)); // false

