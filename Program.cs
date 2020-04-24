using System;

namespace MatrixCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Użycie funkcji do wygenerowania wartości komórek o rozmiarach podanych przez użytkownika, dodania ich oraz wyświetlenia w konsoli.
            int height = GetIntFromConsole("Jak wysoka macierz?: ");
            int width = GetIntFromConsole("Jak szeroka macierz?: ");
            int min = GetIntFromConsole("Od jakiej liczby wartości komórek?: ");
            int max = GetIntFromConsole("Do jakiej liczby wartości komórek?: ");
            var matrix = new int[height, width];
            var matrix2 = new int[height, width];

            GenerateMatrix(matrix, height, width, min, max);
            PrintMatrix(matrix, height, width);
            Console.WriteLine();
            GenerateMatrix(matrix2, height, width, min, max);
            PrintMatrix(matrix2, height, width);
            Console.WriteLine();
            AddMatrix(matrix, matrix2, height, width);

            Console.ReadKey();
        }

        static void GenerateMatrix(int[,] matrix, int height, int width, int min, int max)
        {
            var lottery = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = lottery.Next(min, max);
                }
            }
        }
        static void PrintMatrix(int[,] matrix, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void AddMatrix(int[,] matrix, int[,] matrix2, int height, int width)
        {
            var score = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    score[i, j] = matrix[i, j] + matrix2[i, j];
                }
            }
            Console.WriteLine("Wynik dodawania macierzy:");
            PrintMatrix(score, height, width);
        }
        static int GetIntFromConsole(string message)
        {
            bool isCorrect = false;
            int result = 0;
            while (!isCorrect)
            {
                try
                {
                    Console.WriteLine(message);
                    result = int.Parse(Console.ReadLine());
                    isCorrect = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podaj poprawny format - liczbę.");
                }
            }
            return result;
        }
    }
}
