using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole
{
    class TaskManager<T> where T : TaskBase
    {
        public static void TaskAdd(List<TaskBase> tasks, T task) => tasks.Add(task);
        public static void TaskRemove(List<TaskBase> tasks, int index) => tasks.RemoveAt(index);
        public static void GetAllTasks(List<TaskBase> Task)  
        {
            for (int i = 0; i < Task.LongCount(); i++)
                Console.WriteLine($"{Task[i].Title}");
        }
    }
}
