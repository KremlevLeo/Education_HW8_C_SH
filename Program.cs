namespace HT8;



class Program
{
    static void Main(string[] args)
    {
        MainManu();
    }
    private static bool MainManu()
    {
        Console.Clear();
        Console.WriteLine("1) Two-Dimensional Array");
        Console.WriteLine("2) Multiply Arrays");
        Console.WriteLine("3) Arithmetic mean of the column;");
        Console.WriteLine("4) Arithmetic mean of the column;");
        Console.WriteLine("5) Exit.");
        Console.Write("\nSelect: ");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Enter number of rows: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter number of colums: ");
                int col = int.Parse(Console.ReadLine());
                int[,] arr = FillArray(row, col);
                Console.WriteLine("Sort array");
                PrintArray(SortArrStr(arr));
                return true;
            case "2":
                int[,] arrOne = FillArray(4, 4);
                int[,] arrTwo = FillArray(4, 4);
                MultiArr(arrOne, arrTwo);
                return true;
            case "3":
                Console.Write("Enter size of array: ");
                col = int.Parse(Console.ReadLine());
                row = col;
                int count = 0;
                int tmp = 1;
                int resTmp = col * col + 1;
                arr = new int[row, col];
                while (count <= col)
                {
                    if (tmp != resTmp)
                    {
                        for (int r = count; r < row; r++)
                        {
                            arr[count, r] = tmp++;
                        }
                    }
                    if (tmp != resTmp)
                    {
                        for (int c = count + 1; c < col; c++)
                        {
                            arr[c, row - 1] = tmp++;
                        }
                        row--;
                    }
                    if (tmp != resTmp)
                    {
                        for (int r = row - 1; r >= count; r--)
                        {
                            arr[col - 1, r] = tmp++;
                        }
                    }
                    if (tmp != resTmp)
                    {
                        for (int c = col - 2; c > count; c--)
                        {
                            arr[c, count] = tmp++;
                        }
                        col--;
                    }
                    count++;
                }
                PrintArray(arr);
                return true;
            case "4":
                int[,,] array3D = CreateMatrix(2, 2, 2, 10, 99);
                PrintMatrix(array3D);
                return true;
            case "5":
                return false;
            default:
                return false;
        }
    }
    private static void PrintArray(int[,] arr)
    {

        for (int r = 0; r < arr.GetLength(0); r++)
        {
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                Console.Write($"{arr[r, c]} \t");
            }
            Console.WriteLine();
        }
    }

    private static int[,] SortArrStr(int[,] arr)
    {

        for (int r = 0; r < arr.GetLength(0); r++)
        {
            int temp;
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                for (int cx = c + 1; cx < arr.GetLength(1); cx++)
                {
                    if (arr[r, c] < arr[r, cx])
                    {
                        temp = arr[r, c];
                        arr[r, c] = arr[r, cx];
                        arr[r, cx] = temp;
                    }
                }
            }
        }
        return arr;
    }

    private static int[,] FillArray(int row, int col)
    {
        int[,] arr = new int[row, col];
        Random rnd = new Random();
        for (int r = 0; r < arr.GetLength(0); r++)
        {
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                arr[r, c] = rnd.Next(1, 10);
                Console.Write($"{arr[r, c]} \t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        return arr;
    }
    private static int[,] MultiArr(int[,] a, int[,] b)
    {
        int[,] resArr = new int[4, 4];
        for (int r = 0; r < resArr.GetLength(0); r++)
        {
            for (int c = 0; c < resArr.GetLength(1); c++)
            {
                resArr[r, c] = a[r, c] * b[r, c];
                Console.Write($"{resArr[r, c]} \t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        return resArr;
    }
    static int[,,] CreateMatrix(int row, int col, int dep, int min, int max)
    {
        int[,,] matrix = new int[row, col, dep];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int k = 0; k < matrix.GetLength(2); k++) { matrix[i, j, k] = GetUniqueValue(matrix, min, max, i, j, k); }
            }
        }
        return matrix;
    }
    static Random rnd = new Random();
    /// <summary>
    /// Отдает уникальное для <paramref name="matrix"/> значение
    /// </summary>
    /// <param name="matrix">сама матрица</param>
    /// <param name="min">минимальное значение для рандомайзера</param>
    /// <param name="max">максимальное значение для рандомайзера</param>
    /// <param name="i">текущая итерация <paramref name="i"/></param>
    /// <param name="j">текущая итерация <paramref name="j"/></param>
    /// <param name="k">текущая итерация <paramref name="k"/></param>
    /// <returns>Уникальное для <paramref name="matrix"/> значение</returns>
    private static int GetUniqueValue(int[,,] matrix, int min, int max, int i, int j, int k)
    {
        int value = default;
        bool exist = true;
        while (exist)
        {
            bool _break = false;
            value = rnd.Next(min, max + 1);
            for (int i1 = 0; i1 < matrix.GetLength(0); i1++)
            {
                if (_break) { break; }
                for (int j1 = 0; j1 < matrix.GetLength(1); j1++)
                {
                    if (_break) { break; }
                    for (int k1 = 0; k1 < matrix.GetLength(2); k1++)
                    {
                        if (matrix[i1, j1, k1] == value) { _break = true; break; }
                        if (i1 == i && j1 == j && k1 == k) { exist = false; }
                    }
                }
            }
        }
        return value;
    }
    private static void PrintMatrix(int[,,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("|");
                for (int k = 0; k < matrix.GetLength(2); k++) { Console.Write($"{matrix[i, j, k],1}({i},{j},{k})|"); }
                Console.WriteLine();
            }
        }
    }
}


