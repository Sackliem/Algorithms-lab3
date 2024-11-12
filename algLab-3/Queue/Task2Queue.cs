using System.Diagnostics;

namespace algLab_3.Queue
{
    /// <summary> Часть 2. Задание 2. </summary>
    public class Task2Queue
    {
        public static double ParsingAndExecutingOperations(IQueue<object> iQueue, string str)
        {
            var queue = (Queue.Queue<object>)iQueue;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var commands = str.Split(' ');

            foreach (var command in commands)
            {
                if (command.Contains("1,"))
                {
                    var element = command.Split(',')[1];
                    queue.Enqueue(element);
                    Console.WriteLine($"Добавлен элемент: {element}");
                }

                switch (command)
                {
                    case "2":
                        try
                        {
                            Console.WriteLine($"Извлечён элемент: {queue.Dequeue()}");
                        }
                        catch
                        {
                            Console.WriteLine("Нельзя извлечь элемент, так как очередь пустая.");
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine($"Первый элемент очереди: {queue.First()}");
                        }
                        catch
                        {
                            Console.WriteLine("Нельзя получить первый элемент, так как очередь пустая.");
                        }
                        break;
                    case "4":
                        Console.WriteLine($"Коллекция пуста: {queue.IsEmpty()}");
                        break;
                    case "5":
                        queue.Print();
                        break;
                }
            }
            stopWatch.Stop();
            System.Console.WriteLine("Затрачено времени в милисекундах:");
            System.Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            return stopWatch.Elapsed.TotalMilliseconds;
        }

        internal static void ParsingAndExecutingOperations(Queue<int> queue, string v)
        {
            throw new NotImplementedException();
        }
    }
}
