using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algLab_3.Examples
{


    class Process
    {
        public string Name { get; set; }
        public int BurstTime { get; set; } // Время выполнения процесса

        public Process(string name, int burstTime)
        {
            Name = name;
            BurstTime = burstTime;
        }
    }

    class RoundRobinScheduler
    {
        private Queue<Process> processQueue = new Queue<Process>();
        private int timeQuantum;

        public RoundRobinScheduler(int timeQuantum)
        {
            this.timeQuantum = timeQuantum;
        }

        public void AddProcess(Process process)
        {
            processQueue.Enqueue(process);
        }

        public void Execute()
        {
            while (processQueue.Count > 0)
            {
                Process current = processQueue.Dequeue();

                if (current.BurstTime > timeQuantum)
                {
                    Console.WriteLine($"Executing {current.Name} for {timeQuantum}ms. Remaining time: {current.BurstTime - timeQuantum}ms.");
                    current.BurstTime -= timeQuantum;
                    processQueue.Enqueue(current); // Возвращаем в очередь с оставшимся временем
                }
                else
                {
                    Console.WriteLine($"Executing {current.Name} for {current.BurstTime}ms. Process completed.");
                }
            }
        }

        
    }

    class RobinExec
    {
        public static void RoundRobin_Execution()
        {
            RoundRobinScheduler scheduler = new RoundRobinScheduler(4); // Time quantum = 4ms

            scheduler.AddProcess(new Process("P1", 10));
            scheduler.AddProcess(new Process("P2", 4));
            scheduler.AddProcess(new Process("P3", 6));

            scheduler.Execute();
        }
    }


}
