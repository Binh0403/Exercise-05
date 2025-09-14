
internal class Program
{
    private static void Main(string[] args)
    {
        // 1. Find max of three numbers
        Console.WriteLine("Enter 3 numbers:");
        if (!int.TryParse(Console.ReadLine(), out int a) ||
            !int.TryParse(Console.ReadLine(), out int b) ||
            !int.TryParse(Console.ReadLine(), out int c))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        int max = FindMaximum(a, b, c);
        Console.WriteLine($"Maximum is {max}");

        // 2. Factorial
        Console.Write("Enter a number to calculate factorial: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            try { Console.WriteLine($"Factorial of {n} is {Factorial(n)}"); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        // 3. Prime check
        Console.Write("Enter a number to check prime: ");
        if (int.TryParse(Console.ReadLine(), out int checkNum))
            Console.WriteLine(IsPrime(checkNum) ? $"{checkNum} is a prime number" : $"{checkNum} is not a prime number");

        // 4.1 Print primes under a number
        Console.Write("Enter a number to print all primes less than it: ");
        if (int.TryParse(Console.ReadLine(), out int under))
            PrintPrimesUnderNum(under);

        // 4.2 Print first N primes
        Console.Write("Enter N to print first N primes: ");
        if (int.TryParse(Console.ReadLine(), out int N))
            PrintFirstNPrimes(N);

        // 5 Print all perfect numbers under 1000
        Console.WriteLine("Perfect numbers less than 1000:");
        for (int i = 2; i < 1000; i++)
            if (IsPerfect(i)) Console.Write(i + " ");
        Console.WriteLine();

        // 6 Pangram check
        Console.Write("Enter a sentence to check Pangram: ");
        string input = Console.ReadLine();
        Console.WriteLine(IsPangram(input) ? "It is a Pangram" : "It is not a Pangram");
    }

    static int FindMaximum(params int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("At least one number is required.");
        int max = numbers[0];
        foreach (int num in numbers)
            if (num > max) max = num;
        return max;
    }

    static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("Number must be non-negative.");
        long result = 1;
        for (int i = 2; i <= n; i++) result *= i;
        return result;
    }

    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        int limit = (int)Math.Sqrt(num);
        for (int i = 2; i <= limit; i++)
            if (num % i == 0) return false;
        return true;
    }

    static void PrintPrimesUnderNum(int num)
    {
        Console.WriteLine($"Primes less than {num}:");
        for (int i = 2; i < num; i++)
            if (IsPrime(i)) Console.Write(i + " ");
        Console.WriteLine();
    }

    static void PrintFirstNPrimes(int n)
    {
        Console.WriteLine($"First {n} primes:");
        int count = 0, number = 2;
        while (count < n)
        {
            if (IsPrime(number))
            {
                Console.Write(number + " ");
                count++;
            }
            number++;
        }
        Console.WriteLine();
    }

    static bool IsPerfect(int num)
    {
        int sum = 0;
        for (int i = 1; i <= num / 2; i++)
            if (num % i == 0) sum += i;
        return sum == num;
    }

    static bool IsPangram(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        input = input.ToLower();
        return Enumerable.Range(0, 26).All(i => input.Contains((char)('a' + i)));
    }
}
