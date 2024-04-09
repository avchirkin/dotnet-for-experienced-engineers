
int[] oneDimensionalArray = new int[5]; // Одномерный массив
int[,] twoDimensionalArray = new int[2, 3]; // Двумерный массив
int[,,] threeDimensionalArray = new int[2, 3, 4]; // Трёхмерный массив (max array rank (dimensions number) = 32)

oneDimensionalArray = [1, 2, 3];

// twoDimensionalArray = { { 0, 1, 2 }, { 3, 4, 5} }; // Упрощенная инициализация с фигурными скобками доступна только вместе с объявлением

int[,] twoDimensionalArray2 = { { 0, 1, 2 }, { 3, 4, 5 } }; // Ок

var twoDimensionalArray3 = new int[2,3] { { 0, 1, 2 }, { 3, 4, 5 } }; // Ок

var twoDimensionalArray4 = new int[,] { { 0, 1, 2, 42 }, { 3, 4, 5, 42 } }; // Ок

var twoDimensionalArray5 = new [,]
{
    { 0, 1, 2, 42 },
    { 3, 4, 5, 42 } 
}; // Ок

/*
var twoDimensionalArray6 = new[,]
{
    { 0, 1, 2, 42 },
    { 3, 4, 5, 42, 26 } // Ошибка - размерность измерений не совпадает
}; // Ок
*/


