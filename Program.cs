using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole
{
    class Program
    {
        static TaskBase TaskCreated(TaskBase Task) 
        {
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
            return Task;
        }
        static void FunctionTask(List<TaskBase> Task, int num)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.T:
                    Task[num - 1].IsComplected = true;
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("Введите новое описание:");
                    Task[num - 1].Description = Console.ReadLine();
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Введите новое название:");
                    Task[num - 1].Title = Console.ReadLine();
                    break;
                case ConsoleKey.Backspace:
                    break;
            }
        }
        static void Filter(List<TaskBase> Task)
        {
            byte num = byte.Parse(Console.ReadLine());
            for (int i = 0; i < Task.LongCount(); i++)
            {
                if (Task[i] is PersonalTask  && num == 1)
                    Console.WriteLine(Task[i].Title);
                else if (Task[i] is WorkTask && num == 2)
                    Console.WriteLine(Task[i].Title);
                else if (Task[i].IsComplected && num == 3)
                    Console.WriteLine(Task[i].Title);
            }
        }
        static void Main(string[] args)
        {
            List<TaskBase> Task = new List<TaskBase>();
            int Quantity = 0;
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Текущий список задач: ");
                    TaskManager<TaskBase>.GetAllTasks(Task);
                    Console.WriteLine($"\nN - Создать новую задачу\nS - сортировать задачи\nEnd - завершить прогрaмму\nПерейти к выбору задачи Enter");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.S)
                    {
                        Console.Clear();
                        Console.WriteLine($"1.Показать только личные задачи\n2.Показать только рабочие задачи\n3.Показать только выполненные задачи");
                        Filter(Task);
                        Console.ReadLine();
                        continue;
                    }
                    Console.WriteLine();
                    if (key == ConsoleKey.N)
                    {
                        TaskManager<TaskBase>.TaskAdd(Task, new PersonalTask("", "", 0));
                        Task[Quantity] = TaskCreated(Task[Quantity]);
                        Quantity++;
                        continue;
                    }
                    Console.WriteLine("Введите номер нужной задачи");
                    int num = int.Parse(Console.ReadLine());
                    if (num > Task.LongCount() | num <= 0)
                    {
                        Console.WriteLine("Задачи под таким номером не существует!");
                        Console.ReadLine();
                        continue;
                    }
                    Console.Clear();

                    Console.WriteLine($"R - перезаписать элемент или позначить как выполненное\nP - вывести данные о задаче\nDelete - удалить эту задачу");
                    ConsoleKey key2 = Console.ReadKey().Key;
                    if (key2 == ConsoleKey.R)
                    {
                        Console.WriteLine($"C - поменять название\nD - поменять описание\nT - позначить как выполненное");
                        FunctionTask(Task, num);
                        Console.Clear();
                    }
                    if (key2 == ConsoleKey.Delete)
                    {
                        TaskManager<TaskBase>.TaskRemove(Task, num - 1);
                        Console.WriteLine("Обьект успешно удален!");
                    }
                    if (key2 == ConsoleKey.P)
                    {
                        Task[num - 1].PrintInfo();
                        Console.ReadLine();
                        Console.Clear();
                    }
                    if (key == ConsoleKey.End)
                        break;
                }
                catch (Exception)
                {
                    Console.WriteLine("EXCEPTION!");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}
