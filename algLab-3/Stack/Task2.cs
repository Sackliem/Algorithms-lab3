using System.Diagnostics;

namespace algLab_3.Stack
{
    /// <summary> Часть 1. Задание 2. </summary>
    public class Task2
    {
        /// <summary> Парсить выражение и выполнять операции </summary>
        /// <param name="iStack"> Стек для выполнения операций </param>
        /// <param name="str"> Выражение для парсинга </param>
        /// <returns> Время требуемое на выполнение операций из выражения в миллисекундах </returns>
        public static double ParsingAndExecutingOperations(IStack<object> iStack, string str)
        {
            var stack = (Stack.Stack<object>) iStack;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var commands = str.Split(' ');

            foreach (var command in commands)
            {
                if (command.Contains("1,"))
                {
                    var element = command.Split(',')[1];
                    stack.Push(element);
                    Console.WriteLine($"Добавлен элемент: {element}");
                }

                switch (command)
                {
                    case "2":
                        try
                        {
                            Console.WriteLine($"Извлечён элемент: {stack.Pop()}");
                        }
                        catch
                        {
                            Console.WriteLine("Нельзя извлечь элемент из стека, стек пуст.");
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine($"Вершина стека: {stack.Top()}");
                        }
                        catch
                        {
                            Console.WriteLine("Нельзя получить вершину стека, стек пуст.");
                        }
                        break;
                    case "4":
                        Console.WriteLine($"Коллекция пуста: {stack.IsEmpty()}");
                        break;
                    case "5":
                        stack.Print();
                        break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Затрачено времени в милисекундах:");
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds.ToString(), "мс");
            return stopWatch.Elapsed.TotalMilliseconds;
        }
    }
}
