using System;

namespace Lotto
{
    class test
    {
        static int kln;
        static int[,] mat = new int[6, 11];
        static int[] arr = new int[6];
        static void Random(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 46);
            }
        }
        static void Menual(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    bool flag = true;
                    int tmp = 0;
                    Console.WriteLine("Enter {0} number of {1} cole: ", j + 1, i + 1);
                    string str = Console.ReadLine();
                    for (int m = 0; m < str.Length; m++)
                    {
                        if ((str[m] < '0') || (str[m] > '9'))
                        {
                            Console.WriteLine("this is not a number, please insert a number between 1 to 45:");
                            str = Console.ReadLine();
                        }
                    }
                    tmp = int.Parse(str);
                    if ((tmp <= 0) || (tmp > 45))
                    {
                        flag = false;
                        Console.WriteLine("the value is too big or too small, please insert a number between 1 to 45:");
                        j--;
                    }
                    for (int r = 0; r < j; r++)
                    {
                        if (tmp == mat[i, r])
                        {
                            flag = false;
                            Console.WriteLine("This number already exists Please enter a different number from 1 to 45:");
                            j--;
                        }
                    }
                }
            }
        }
        static int OneTur(int[] arr, int[,] mat, int kln)
        {

            int qq = 0;
            for (int i = 0; i < kln; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (mat[i, kln] == arr[x])
                    {
                        qq++;
                    }
                }
            }
            return qq;
        }
        static void AllTur(int[,] mat, int[] arr, int kln)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {

                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    int res = OneTur(arr, mat, kln);
                    if (res == 6)
                    {
                        Console.WriteLine("You win!!!");
                    }
                }
            }


        }
        
    }
}