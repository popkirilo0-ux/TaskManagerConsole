using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskBase Task = new PersonalTask("", "", 0);
            Console.WriteLine("Введите название:");
            string Title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите описание:");
            string Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Какой тип задачи?\nW - Рабочая задача\nP - Личная задача");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    Console.WriteLine("Укажите дедлайны: год, месяц, день");
                    int Year = int.Parse(Console.ReadLine());
                    int Month = int.Parse(Console.ReadLine());
                    int Day = int.Parse(Console.ReadLine());
                    Task = new WorkTask(Title, Description, new DateTime(Year, Month, Day));
                    break;
                case ConsoleKey.P:
                    Console.WriteLine("Укажите приоритет от 0 до 10");
                    byte prioritet = byte.Parse(Console.ReadLine());
                    Task = new PersonalTask(Title, Description, prioritet);
                    break;
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"R - перезаписать элемент или позначить как выполненное\nP - вывести данные о списке\nEnd - завершить прогрмму");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.R)
                {
                    Console.WriteLine($"C - поменять название\nD - поменять описание\nT - позначить как выполненное");
                    switch (Console.ReadKey().Key)
                    { 
                        case ConsoleKey.C:
                            Task.IsComplected = true;
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Введите новое описание:");
                            Task.Description = Console.ReadLine();
                            break;
                        case ConsoleKey.T:
                            Console.WriteLine("Введите новое название:");
                            Task.Title = Console.ReadLine();
                            break;
                        case ConsoleKey.Backspace:
                            break;
                    }
                    Console.Clear();
                }
                if (key == ConsoleKey.P)
                {
                    Task.PrintInfo();
                    Console.ReadLine();
                    Console.Clear();
                }
                if (key == ConsoleKey.End)
                    break;
            }
        }
    }
}
