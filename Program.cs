using ConsoleIO;
using MyArrays;

main();

void main()
{
    bool isWork = true;

    while (isWork)
    {
        ConsoleIOHandler.PrintMainMenu();

        int taskNo = ConsoleIOHandler.ReadInt("a task number", 0, 3, ConsoleIOHandler.msgNoSuchOption);

        switch (taskNo)
        {
            case 1: Task47CreateRandomMatrix(); break;
            case 2: Task50ElementByPosition(); break;
            case 3: Task52ColumnsAverage(); break;
            case 0: isWork = false; break;
            default: System.Console.WriteLine(ConsoleIOHandler.msgNoSuchOption); break;
        }

        if (isWork)
            ConsoleIOHandler.WaitForAnyKey();
    }
}

#region Task47 Create a matrix of random real numbers
// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9
void Task47CreateRandomMatrix()
{
    Console.Clear();

    double[,] matrix = ArrayHandler.GetRandomMatrix(ConsoleIOHandler.ReadInt("number of rows"),
                                                    ConsoleIOHandler.ReadInt("number of columns"),
                                                    ConsoleIOHandler.ReadDouble("minimal value"),
                                                    ConsoleIOHandler.ReadDouble("maximum value"),
                                                    ConsoleIOHandler.ReadInt("number of digits to be rounded"));

    System.Console.WriteLine(ArrayHandler.MatrixToString(matrix));
}
#endregion

#region Task50 Element by position
// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет
void Task50ElementByPosition()
{
    Console.Clear();
    
    int[,] matrix = ArrayHandler.GetRandomMatrix(5, 5, 0);

    System.Console.WriteLine($"Matrix {matrix.GetLength(0)}x{matrix.GetLength(1)}:");
    System.Console.WriteLine(ArrayHandler.MatrixToString(matrix));

    System.Console.WriteLine("Choose position of an element.");

    int row = ConsoleIOHandler.ReadInt("row") - 1;
    int col = ConsoleIOHandler.ReadInt("column") - 1;

    if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
        System.Console.WriteLine("There is no such element");
    else
        System.Console.WriteLine($"Element on the position ({row+1}, {col+1}) is {matrix[row, col]}");

}
#endregion

#region Task52 Average of columns
// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
void Task52ColumnsAverage()
{
    Console.Clear();

    int[,] matrix = ArrayHandler.GetRandomMatrix(ConsoleIOHandler.ReadInt("number of rows"),
                                                    ConsoleIOHandler.ReadInt("number of columns"),
                                                    0, 10);

    System.Console.WriteLine($"Matrix {matrix.GetLength(0)}x{matrix.GetLength(1)}:");
    System.Console.WriteLine(ArrayHandler.MatrixToString(matrix));

    double[] columnAverage = new double[matrix.GetLength(1)];

    for (int j = 0; j < matrix.GetLength(1); j++)
        {
            columnAverage[j] = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                columnAverage[j] += matrix[i,j];
            columnAverage[j] = Math.Round(columnAverage[j] / matrix.GetLength(0), 2);
        }
    
    System.Console.WriteLine("Averages of the columns:");
    System.Console.WriteLine(ArrayHandler.ArrayToString(columnAverage));
}
#endregion