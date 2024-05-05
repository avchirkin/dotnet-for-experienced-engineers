﻿using System.Text;

// Пример работы с кодировками взят из https://learn.microsoft.com/ru-ru/dotnet/api/system.text.encoding?view=net-8.0

string unicodeString = "This string contains the unicode character Pi (\u03a0)";

// Create two different encodings.
Encoding ascii = Encoding.ASCII;
Encoding unicode = Encoding.Unicode;

// Convert the string into a byte array.
byte[] unicodeBytes = unicode.GetBytes(unicodeString);

// Perform the conversion from one encoding to the other.
byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
         
// Convert the new byte[] into a char[] and then into a string.
char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
string asciiString = new string(asciiChars);

// Display the strings created before and after the conversion.
Console.WriteLine("Original string: {0}", unicodeString);
Console.WriteLine("Ascii converted string: {0}", asciiString);