using algLab_3.Lists;

namespace algLab_3.ConsoleInput
{
    /// <summary> Вспомогательный класс консольного меню </summary>
    public static class ConsoleHelper
    {
        /// <summary> Получить коллекцию элементов от ввода пользователя </summary>
        /// <param name="message"> Выводимое сообщение </param>
        private static IEnumerable<string> GetInputElements(string message = "Введите список целочисленных элементов (разделитель пробел): ")
        {
            System.Console.Write(message);
            var src = System.Console.ReadLine();
            return src != null ? src.Split(' ') : Array.Empty<string>();
        }

        /// <summary> Получить список целых чисел из консольного ввода от пользователя </summary>
        /// <param name="list"> Коллекция для записи </param>
        public static Lists.ICollection<int> GetListIntegerNumbersFromConsoleInput(Lists.ICollection<int> list)
        {
            var input = GetInputElements();
            foreach (var item in input)
            {
                if (!int.TryParse(item, out var element)) throw new InvalidCastException("ОШИБКА: нужно ввести целочисленные элементы списка через пробел.");
                list.Add(element);
            }

            return list;
        }

        // Методы выполнения различных алгоритмов
        #region ExecuteAlgorithm

        public static void ExecuteAlgorithm<T>(int numAlg, Func<string, T> alg, string message)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            System.Console.Write(message);
            var input = System.Console.ReadLine() ?? "";
            var result = alg(input);
            System.Console.WriteLine($"Результат: {result}");
        }

        public static void ExecuteOneLinkedListAlgorithm(int numAlg, Action<Lists.LinkedList<int>> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.LinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                alg(list);
                System.Console.Write("\nРезультат: ");
                PrintList(list, 1);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteOneLinkedListAndTargetAlgorithm(int numAlg, Action<Lists.LinkedList<int>, int> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.LinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write("Введите опорный элемент: ");
                if (!int.TryParse(System.Console.ReadLine(), out var target)) throw new InvalidCastException("ОШИБКА: нужно ввести целочисленный элемент.");
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                alg(list, target);
                System.Console.Write("\nРезультат: ");
                PrintList(list, 1);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteTwoLinkedListAlgorithm(int numAlg, Action<Lists.LinkedList<int>, Lists.LinkedList<int>> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list1 = new Lists.LinkedList<int>();
            var list2 = new Lists.LinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list1);
                System.Console.Write("Входной список: ");
                PrintList(list1, 1);
                GetListIntegerNumbersFromConsoleInput(list2);
                System.Console.Write("Входной список: ");
                PrintList(list2, 2);
                alg(list1, list2);
                System.Console.Write("\nРезультат: ");
                PrintList(list1, 1);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteOneDuplexLinkedListAlgorithm(int numAlg, Action<Lists.DuplexLinkedList<int>> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.DuplexLinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                alg(list);
                System.Console.Write("\nРезультат: ");
                PrintList(list, 1);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteOneDuplexLinkedListAndElementAlgorithm(int numAlg, Action<Lists.DuplexLinkedList<int>, int> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.DuplexLinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write("Введите элемент: ");
                if (!int.TryParse(System.Console.ReadLine(), out var element)) throw new InvalidCastException("ОШИБКА: нужно ввести целочисленный элемент.");
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                alg(list, element);
                System.Console.Write("\nРезультат: ");
                PrintList(list, 1);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteReturnTwoDuplexLinkedListAlgorithm(int numAlg, Func<Lists.DuplexLinkedList<int>, int, Lists.DuplexLinkedList<int>> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.DuplexLinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write("Введите опорный элемент: ");
                if (!int.TryParse(System.Console.ReadLine(), out var element)) throw new InvalidCastException("ОШИБКА: нужно ввести целочисленный элемент.");
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                var list2 = alg(list, element);
                System.Console.Write("\nРезультат: ");
                PrintList(list, 1);
                PrintList(list2, 2);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteOneDuplexLinkedListAndTwoElementAlgorithm(int numAlg, Action<Lists.DuplexLinkedList<int>, int, int> alg, bool index = false)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.DuplexLinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write(index ? "Введите индекс первого элемента: " : "Введите опорный элемент: ");
                if (!int.TryParse(System.Console.ReadLine(), out var target)) throw new InvalidCastException("ОШИБКА: нужно ввести целочисленный опорный элемент.");
                System.Console.Write(index ? "Введите индекс второго элемента: " :"Введите элемент: ");
                if (!int.TryParse(System.Console.ReadLine(), out var element)) throw new InvalidCastException("ОШИБКА: нужно ввести целочисленный элемент.");
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                alg(list, target, element);
                System.Console.Write("\nРезультат: ");
                PrintList(list, 1);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteOneDuplexLinkedListAlgorithm(int numAlg, Func<Lists.DuplexLinkedList<int>, int> alg)
        {
            System.Console.WriteLine($"Выбрано действие: {numAlg}.");
            var list = new Lists.DuplexLinkedList<int>();
            try
            {
                GetListIntegerNumbersFromConsoleInput(list);
                System.Console.Write("Входной список: ");
                PrintList(list, 1);
                var result = alg(list);
                System.Console.WriteLine($"\nРезультат: {result}.");
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void ExecuteReturn(Action basePage, Action mainPage)
        {
            System.Console.WriteLine("\nНажмите Enter, чтобы вернуться к выбору действия.\nНажмите Escape, чтобы вернуться в главное меню.");
            ConsoleKey key = default;
            while (key is not (ConsoleKey.Enter or ConsoleKey.Escape))
            {
                key = System.Console.ReadKey(true).Key;
            }
            System.Console.Clear();
            switch (key)
            {
                case ConsoleKey.Enter:
                    basePage();
                    break;
                case ConsoleKey.Escape:
                    mainPage();
                    break;
            }
        }

        #endregion

        /// <summary> Печать списка в консоль </summary>
        /// <typeparam name="T"> Тип элементов списка </typeparam>
        /// <param name="list"> Список для печати </param>
        /// <param name="num"> Номер списка в консоли </param>
        public static void PrintList<T>(Lists.ICollection<T> list, int num)
        {
            System.Console.Write($"list{num} = {{ ");
            var flag = true;
            foreach (var item in list)
            {
                System.Console.Write(flag ? $"{item}" : $", {item}");
                flag = false;
            }
            System.Console.WriteLine(" }");
        }
    }
}
