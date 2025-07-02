using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Stopwatch;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Informe quanto tempo deseja contar:");
        Console.WriteLine("S - Segundos (10s)");
        Console.WriteLine("M - Minuto (1m)");
        Console.WriteLine("0 - Sair");

        int time;
        string input = ValidationInput(Console.ReadLine());
        string inputNumber = input.Substring(0, input.Length == 1 ? 1 : input.Length - 1);
        Console.WriteLine("Chegou aquii??");

        if (int.TryParse(inputNumber, out time))
        {
            int multiplier = 1;
            if (time == 0)
                System.Environment.Exit(0);

            char type = char.Parse(input.Substring(input.Length - 1, 1));
            if (type == 'm')
                multiplier = 60;

            Start(time * multiplier);
        }
        else
        {
            Console.WriteLine("O tempo informado excede o limite máximo, pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Menu();
        }
    }

    static void Start(int time)
    {
        int currentTime = 0;

        while (currentTime != time)
        {
            Console.Clear();
            currentTime++;
            Console.WriteLine(currentTime);
            Thread.Sleep(1000);
        }

        Console.WriteLine("O contador finalizou, pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        Menu();
    }

    static string ValidationInput(string? input)
    {    
        do
        {
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("É obrigatório informar uma opção. Verifique!");
                input = Console.ReadLine();
            }

            bool isMatch;
            do
            {
                string pattern = @"^\d+[sSmM]$";
                isMatch = Regex.IsMatch(input, pattern);
                if (!isMatch)
                    Console.WriteLine("É obrigatório estar no formato correto. Verifique!");
                    input = Console.ReadLine();
            } while (!isMatch && !String.IsNullOrEmpty(input));
        }
        while (String.IsNullOrEmpty(input));
        return input;
    }
}
