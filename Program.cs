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
        Console.WriteLine("4) Exit.");
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
                int count=0;
                int tmp=1;
                int resTmp = col*col;
                arr = new int[row, col];
                while (count <= col)
                {
                    if (tmp != resTmp+1)
                    {
                        for (int r = count; r < row; r++)
                        {
                            arr[count, r] = tmp++;
                        }
                    }
                    if (tmp != resTmp+1)
                    {
                        for (int c = count+1; c < col; c++)
                        {
                            arr[c, row-1] = tmp++;
                        }
                        row--;
                    }
                    if (tmp != resTmp+1)
                    {
                        for (int r = row - 1; r >= count; r--)
                        {
                            arr[col-1, r] = tmp++;
                        }
                    }
                    if (tmp != resTmp+1)
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
}


