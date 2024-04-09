// Массив из двух одномерных массивов
int[][] jaggedArray = new int[2][] { [], [] }; // Ок

// Массив из трёх одномерных массивов
int[][] jaggedArray2 = new int[3][] { [], [], [] }; // Ок

// Массив из двух двумерных массивов
int[][,] jaggedArray3 = new int[2][,]; // Ок

// Двумерный массив из массивов 
int[,][] jaggedArray4 = new int[2 ,4][]; // Ок

// Двумерный массив двумерных массивов
int[,][,] jaggedArray5 = new int[5,2][,]; // Ок

// Упрощённая инициализация массива массивов
int[][] jaggedArray6 = 
[
    [ 12, 42, 56 ],
    [ 7, 93 ]
];

Console.WriteLine(jaggedArray6[0][2]); // 56

jaggedArray6[0] = [99, 15, 48, 674];
Console.WriteLine(jaggedArray6[0][2]); // 48

