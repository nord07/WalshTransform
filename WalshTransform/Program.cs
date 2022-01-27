using System;
using System.Linq;

namespace WalshTransform
{
    class Program
    {   
        static void Main(string[] args)
        { 
            Console.Write("Enter function: " + " ");
            string function = Console.ReadLine();
            string[] tableTrue = function.Split(" ");
            
            int numberVariables = Convert.ToInt32(Math.Log(tableTrue.Length, 2));

            string[] vector = new string[Convert.ToInt32(Math.Pow(2, numberVariables))];
            int[] coefficientsWalshHadamard1 = new int[Convert.ToInt32(Math.Pow(2, numberVariables))];
            int[] coefficientsWalshHadamard2 = new int[Convert.ToInt32(Math.Pow(2, numberVariables))];
            
            //создание таблицы
            for (int i = 0; i < Math.Pow(2, numberVariables); i++)
                vector[i] = Convert.ToString(i, 2).PadLeft(numberVariables, '0');

            //первого рода


            //второго рода
            int coeff1 = 0;
            int coeff2 = 0;
            for (int j = 0; j < Math.Pow(2, numberVariables); j++)
            {
                char[] v1 = vector[j].ToCharArray();
                for (int i = 0; i < Math.Pow(2, numberVariables); i++)
                {
                    char[] v2 = vector[i].ToCharArray();

                    int a = 0;
                    for (int g = 0; g < v1.Length; g++) 
                        a += (v1[g] & v2[g]) % 2;

                    coeff1 += Convert.ToInt32(tableTrue[i]) * Convert.ToInt32(Math.Pow(-1, a));
                    coeff2 += Convert.ToInt32(Math.Pow(-1, Convert.ToInt32(tableTrue[i]) ^ a));
                }
                coefficientsWalshHadamard1[j] = coeff1;
                coeff1 = 0;
                coefficientsWalshHadamard2[j] = coeff2;
                coeff2 = 0;
            }
            Console.Write("Коэффициенты Уолша-Адамара первого рода: ");
            foreach (int item in coefficientsWalshHadamard1)
                Console.Write(item + " ");

            Console.WriteLine();

            Console.Write("Коэффициенты Уолша-Адамара второго рода: ");
            foreach (int item in coefficientsWalshHadamard2)
                Console.Write(item + " ");

            Console.ReadLine();
        }
    }
}