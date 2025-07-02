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

        string input = ValidarEntrada(Console.ReadLine());
        int time = int.Parse(input.Substring(0, input.Length == 1 ? 1 : input.Length - 1));
        int multiplier = 1;

        if (time == 0)
            System.Environment.Exit(0);

        char type = char.Parse(input.Substring(input.Length - 1, 1));
        if (type == 'm')
            multiplier = 60;

        Start(time * multiplier);
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

    static bool RequiredInput(string? input)
    {
        if (String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("É obrigatório informar uma opção. Verifique!");
            return false;
        }
        else
        {
            return CurrentFormat(input);
        }
    }

    static bool CurrentFormat(string input)
    {
        string pattern = @"^\d+[sSmM]$";
        bool result = Regex.IsMatch(input, pattern);
        if (!result)
            Console.WriteLine("É obrigatório estar no formato correto. Verifique!");

        return result;
    }

    static string ValidarEntrada(string? input)
    {
        bool result = false;
        while (!result)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("É obrigatório informar uma opção. Verifique!");
                input = Console.ReadLine();
            }
            else
            {
                string pattern = @"^\d+[sSmM]$";
                bool result = Regex.IsMatch(input, pattern);
                if (!result)
                    Console.WriteLine("É obrigatório estar no formato correto. Verifique!");

                input = Console.ReadLine();
            }
        }

        return input;
    }
}
