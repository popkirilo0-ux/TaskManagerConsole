using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole
{
    abstract class TaskBase : IPrintable
    {
        public string Title;
        public string Description;
        public bool IsComplected = false;
        public DateTime CreatedAt = DateTime.Now;
        public abstract void PrintInfo();
    }

    class WorkTask : TaskBase
    {
        public DateTime deadLine;
        public WorkTask()
        {

        }
        public WorkTask(string title,string description, DateTime deadLine) 
        {
            Title = title;
            this.deadLine = deadLine;
            Description = description;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Title: {Title}\n Created in: {CreatedAt}\n Description: {Description}\nDeadLine in {deadLine}\n");
            if (IsComplected)
                Console.WriteLine("Выполненно!");
            else
                Console.WriteLine("Не выполненно");
            if (deadLine < DateTime.Now)
                Console.WriteLine("Начальник даст пиздюлей!");
        }
    }

    class PersonalTask : TaskBase
    {
        public byte prioritet;
        public PersonalTask()
        {
            
        }
        public PersonalTask(string title, string description, byte prioritet)
        {
            Title = title;
            this.prioritet = prioritet;
            Description = description;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Title: {Title}\n Created in: {CreatedAt}\n Description: {Description}\nPrioritet: {prioritet}\n");
            if (IsComplected)
                Console.WriteLine("Выполненно!");
            else
                Console.WriteLine("Не выполненно");
        }
    }
}
