namespace PrimitiveTypes
{
    internal class Program
    {
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types">
        static void Main(string[] args)
        {
            #region Встроенные типы значений (built-in value types)

            // bool (System.Boolean) - булево (1 байт)
            bool yes = true;
            bool no = false;

            // char (System.Char) - символ UTF-16, 2 байта
            char chVal = 'a';
            char minCharVal = char.MinValue; // '\0'
            char maxCharVal = char.MaxValue; // '\uffff'

            // Приведение char к int даст численное значение символа в таблице символов
            Console.WriteLine((int)chVal); // 97
            Console.WriteLine((int)minCharVal); // 0
            Console.WriteLine((int)maxCharVal); // 65535

            #region Целочисленные типы

            // byte (System.Byte) - беззнаковое целое, 1 байт
            byte byteVal = 100;
            byte minByteVal = byte.MinValue; // 0
            byte maxByteVal = byte.MaxValue; // 255

            // sbyte (System.SByte) - знаковое целое, 1 байт
            sbyte sbyteVal = 100;
            sbyte minSbyteVal = sbyte.MinValue; // -128
            sbyte maxSbyteVal = sbyte.MaxValue; // 127

            // short (System.Int16) - знаковое целое, 2 байта
            short shortVal = 100;
            short shortMinVal = short.MinValue; // -32768
            short maxShortVal = short.MaxValue; // 32767

            // ushort (System.UInt16) - беззнаковое целое, 2 байта
            ushort ushortVal = 100;
            ushort ushortMinVal = ushort.MinValue; // 0
            ushort maxUShortVal = ushort.MaxValue; // 65535

            // int (System.Int32) - знаковое целое, 4 байта
            int intVal = 100;
            int intMinVal = int.MinValue; // -2147483648
            int intMaxVal = int.MaxValue; // 2147483647

            // uint (System.UInt32) - беззнаковое целое, 4 байта
            uint uintVal = 100;
            uint minUIntVal = uint.MinValue; // 0
            uint maxUIntVal = uint.MaxValue; // 4294967295

            // long (System.Int64) - знаковое целое, 8 байт
            long longVal = 100;
            var anotherLongVal = 100L; // при использовании var для long приписываем в конце L
            long longMinVal = long.MinValue; // -9223372036854775808
            long longMaxVal = long.MaxValue; // 9223372036854775807

            // ulong (System.UInt64) - беззнаковое целое, 8 байт
            ulong ulongVal = 100;
            var anotherULongVal = 100UL; // при использовании var для ulong приписываем в конце UL
            ulong ulongMinVal = ulong.MinValue; // 0
            ulong ulongMaxVal = ulong.MaxValue; // 18446744073709551615

            // nint (System.IntPtr) - платформонезависимое знаковое целое, 4 или 8 байт
            nint nintVal = 100;
            nint minNIntVal = nint.MinValue; // -9223372036854775808 для 64-разрядной ОС
            nint maxNIntVal = nint.MaxValue; // 9223372036854775807 для 64-разрядной ОС

            // nuint (System.UIntPtr) - платформонезависимое беззнаковое целое, 4 или 8 байт
            nuint nuintVal = 100;
            nuint minNUintVal = nuint.MinValue; // 0
            nuint maxNUintVal = nuint.MaxValue; // 18446744073709551615 для 64-разрядной ОС
            #endregion

            #region Типы вещественных чисел (с плавающей точкой)

            // float (System.Single) - знаковое вещественное, 4 байта
            float floatVal = 100.0F; // для float всегда указываем F
            float minFloatVal = float.MinValue; // -3.40282347E+38F
            float maxFloatVal = float.MaxValue; // 3.40282347E+38F

            // double (System.Double) - знаковое вещественное, 8 байт
            double doubleVal = 100.0;
            var anotherDoubleVal = 100.0D; // при использовании var для double приписываем в конце D
            double doubleMinVal = double.MinValue; // -1.7976931348623157E+308
            double doubleMaxVal = double.MaxValue; // 1.7976931348623157E+308

            // decimal (System.Decimal) - знаковое вещественное, 16 байт
            decimal decVal = 100;
            var anotherDecVal = 200M; // при использовании var для decimal приписываем в конце M
            decimal decMinVal = decimal.MinValue; // -79228162514264337593543950335M
            decimal decMaxVal = decimal.MaxValue; // 79228162514264337593543950335M
            #endregion
            #endregion

            #region Ссылочные встроенные типы (built-in reference types)

            // object (System.Object) - базовый тип для всех типов .NET
            object obj = new object(); // создаем с помощью конструктора
            var anotherObj = new object(); // выведение типа работает на основании правой части выражения

            // string (System.String) - тип, представляющий строку (по существу, является массивом char)
            string str = "Some String";
            string anotherString = new ("another string"); // "another string"
            string yetAnotherString = new ('a', 'b'); // "ab"

            // dynamic (System.Object) - специальный тип, имплементирующий позднее связывание
            dynamic dyn = 100;
            dynamic anotherDyn = dyn + 1; // 101
            // dynamic wrongDyn = dyn.SomeMethod(); // предупреждения компилятора нет, ошибка в рантайме
            #endregion
        }
    }
}
