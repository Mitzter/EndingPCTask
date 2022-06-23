using System;
using System.Collections.Generic;
using System.Linq;

namespace EndingPCTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] threads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int taskToKill = int.Parse(Console.ReadLine());
            
            int killerThread = 0;

            Stack<int> taskStack = new Stack<int>();
            Queue<int> threadQueue = new Queue<int>();

            for (int i = 0; i < tasks.Length; i++)
            {
                taskStack.Push(tasks[i]);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threadQueue.Enqueue(threads[i]);
            }

            for (int i = 0; i < threads.Length; i++)
            {
                int currentTask = taskStack.Peek();
                int currentThread = threadQueue.Peek();
                if (currentTask == taskToKill)
                {
                    killerThread = currentThread;
                    taskStack.Pop();
                    break;
                }
                if (currentThread >= currentTask)
                {
                    
                    threadQueue.Dequeue();
                    taskStack.Pop();
                }
                else if (currentThread < currentTask)
                {
                    threadQueue.Dequeue();
                }

            }
            Console.WriteLine($"Thread with value {killerThread} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threadQueue));




            
        }
    }
}
