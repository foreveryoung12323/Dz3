using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задачу (11-18):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 11:
                Task11.SortString();
                break;
            case 12:
                Task12.FindLongestCommonSubstring();
                break;
            case 13:
                Task13.ReverseWordsInString();
                break;
            case 14:
                Task14.CheckPalindrome();
                break;
            case 15:
                Task15.RemoveDuplicates();
                break;
            case 16:
                Task16.SumEnumeration();
                break;
            case 17:
                Task17.FindGCD();
                break;
            case 18:
                Task18.CompareArrays();
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }
    }
}

// task 11
static class Task11
{
    public static void SortString()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        string sortedString = String.Concat(input.OrderBy(c => c));
        Console.WriteLine($"Отсортированная строка: {sortedString}");
    }
}

// task 12
static class Task12
{
    public static void FindLongestCommonSubstring()
    {
        Console.WriteLine("Введите первую строку:");
        string str1 = Console.ReadLine();
        Console.WriteLine("Введите вторую строку:");
        string str2 = Console.ReadLine();
        string result = LongestCommonSubstring(str1, str2);
        Console.WriteLine($"Наибольшая общая подстрока: {result}");
    }

    private static string LongestCommonSubstring(string s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];
        int maxLength = 0, end = 0;

        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                    if (dp[i, j] > maxLength)
                    {
                        maxLength = dp[i, j];
                        end = i;
                    }
                }
            }
        }

        return s1.Substring(end - maxLength, maxLength);
    }
}

// task 13
static class Task13
{
    public static void ReverseWordsInString()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        string reversed = String.Join(" ", input.Split(' ')
            .Select(word => new string(word.Reverse().ToArray())));
        Console.WriteLine($"Перевёрнутая строка: {reversed}");
    }
}

// task 14
static class Task14
{
    public static void CheckPalindrome()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        bool isPalindrome = IsPalindrome(input);
        Console.WriteLine(isPalindrome ? "Строка является палиндромом." : "Строка не является палиндромом.");
    }

    private static bool IsPalindrome(string str)
    {
        str = str.ToLower().Replace(" ", "");
        return str.SequenceEqual(str.Reverse());
    }
}

// task 15
static class Task15
{
    public static void RemoveDuplicates()
    {
        Console.WriteLine("Введите числа через пробел:");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] uniqueArray = array.Distinct().ToArray();
        Console.WriteLine($"Уникальные значения: {String.Join(", ", uniqueArray)}");
    }
}

// tsak 16
static class Task16
{
    public static void SumEnumeration()
    {
        Console.WriteLine("Введите числа через пробел:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int sum = numbers.Sum();
        Console.WriteLine($"Сумма элементов: {sum}");
    }
}

// task 17
static class Task17
{
    public static void FindGCD()
    {
        Console.WriteLine("Введите два числа через пробел:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        if (numbers.Length != 2)
        {
            Console.WriteLine("Введите ровно два числа.");
            return;
        }

        int gcd = GCD(numbers[0], numbers[1]);
        Console.WriteLine($"НОД ({numbers[0]}, {numbers[1]}) = {gcd}");
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

// task 18
static class Task18
{
    public static void CompareArrays()
    {
        Console.WriteLine("Введите первый массив чисел через пробел:");
        int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine("Введите второй массив чисел через пробел:");
        int[] array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        bool areEqual = array1.SequenceEqual(array2);
        Console.WriteLine(areEqual ? "Массивы равны." : "Массивы не равны.");
    }
}
