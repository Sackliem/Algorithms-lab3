using System.Text;
using algLab_3.Examples;
using algLab_3.Lists;
using algLab_3.Tests;

namespace algLab_3.ConsoleInput
{
    public class Console
    {
        /// <summary> Страница алгоритмов со стеком </summary>
        public static void StackPage()
        {
            System.Console.WriteLine(
@"Про стеки
------------------------------------------------
1. Замер времени на считывание и выполнение операций стеком.
2. Вычисление выражения в постфиксной записи.
3. Инфиксная запись в постфикс
4. Выйти в главное меню.
------------------------------------------------");
            var value = 0;
            while (value is not (1 or 2 or 3))
            {
                var top = System.Console.GetCursorPosition().Top;
                var left = System.Console.GetCursorPosition().Left;
                System.Console.Write("Введите порядковый номер: ");
                _ = int.TryParse(System.Console.ReadLine(), out value);
                System.Console.SetCursorPosition(System.Console.GetCursorPosition().Left, System.Console.GetCursorPosition().Top - 1);
                System.Console.Write(new string(' ', System.Console.BufferWidth));
                System.Console.SetCursorPosition(left, top);
            }

            switch (value)
            {
                case 1:
                    {
                        Tester testings = new Tests.Tester();
                        System.Console.WriteLine("Динамический тест:");
                        testings.Testing(TypeTest.Stack);
                        System.Console.WriteLine("Фикс длины:");
                        testings.TestingWithFixedLength(TypeTest.Stack, null, 1000);

                        ConsoleHelper.ExecuteReturn(StackPage, MainPage);
                        break;
                    }
                case 2:
                    {
                        ConsoleHelper.ExecuteAlgorithm(value, Stack.Task4.Calculate, "Введите выражение (постфикс): ");
                        ConsoleHelper.ExecuteReturn(StackPage, MainPage);
                        break;
                    }
                case 3:
                    {
                        ConsoleHelper.ExecuteAlgorithm(value, Stack.Task5.InfixToPrefix, "Введите выражение (инфикс): ");
                        ConsoleHelper.ExecuteReturn(StackPage, MainPage);
                        break;
                    }

                case 4:
                    {
                        System.Console.Clear();
                        MainPage();
                        break;
                    }
            }
        }


        /// <summary> Страница алгоритмов со стеком </summary>
        public static void QueuePage()
        {
            System.Console.WriteLine(
@"Про стеки
------------------------------------------------
1. Замер времени на считывание и выполнение операций Очередью.
2. Выйти в главное меню.
------------------------------------------------");
            var value = 0;
            while (value is not (1 or 2))
            {
                var top = System.Console.GetCursorPosition().Top;
                var left = System.Console.GetCursorPosition().Left;
                System.Console.Write("Введите порядковый номер: ");
                _ = int.TryParse(System.Console.ReadLine(), out value);
                System.Console.SetCursorPosition(System.Console.GetCursorPosition().Left, System.Console.GetCursorPosition().Top - 1);
                System.Console.Write(new string(' ', System.Console.BufferWidth));
                System.Console.SetCursorPosition(left, top);
            }

            switch (value)
            {
                case 1:
                    {
                        Tester testings = new Tests.Tester();
                        System.Console.WriteLine("Динамический тест:");
                        testings.Testing(TypeTest.Queue);
                        System.Console.WriteLine("Фикс длины:");
                        testings.TestingWithFixedLength(TypeTest.Queue, null, 1000);

                        ConsoleHelper.ExecuteReturn(QueuePage, MainPage);
                        break;
                    }

                case 3:
                    {
                        System.Console.Clear();
                        MainPage();
                        break;
                    }
            }
        }


        /// <summary> Страница алгоритмов со списками </summary>
        public static void AlgorithmsList()
        {
            System.Console.WriteLine(
@"Алгоритмы со списками
----------------------------------------------------------------------------------------------------
1. Перевернуть список (элементы будут расположены в обратном порядке).
2. Перенести в начало/(конец) списка последний/(первый) элемент.
3. Определить количество различных элементов списка.
4. Выполнить удаление повторяющихся элементов из списка.
5. Выполнить вставку списка самого в себя за первым вхождение указанного элемента.
6. Вставить в упорядоченный список (по не убыванию) элемент так, чтобы сохранялась упорядоченность.
7. Удалить из списка все указанные элементы, если таковые имеются.
8. Вставить в список новый элемент, за первым вхождением опорного элемента, если таковой есть.
9. Дописать к одному списку второй.
10. Выполнить разбиение списка на два по первому вхождению опорного элемента.
11. Выполнить удваивание списка.
12. Поменять местами два элемента списка.
13. Выйти в главное меню.
----------------------------------------------------------------------------------------------------");
            var value = 0;
            while (value is not (1 or 2 or 3 or 4 or 5 or 6 or 7 or 8 or 9 or 10 or 11 or 12 or 13))
            {
                var top = System.Console.GetCursorPosition().Top;
                var left = System.Console.GetCursorPosition().Left;
                System.Console.Write("Введите порядковый номер: ");
                _ = int.TryParse(System.Console.ReadLine(), out value);
                System.Console.SetCursorPosition(System.Console.GetCursorPosition().Left, System.Console.GetCursorPosition().Top - 1);
                System.Console.Write(new string(' ', System.Console.BufferWidth));
                System.Console.SetCursorPosition(left, top);
            }

            switch (value)
            {
                case 1:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAlgorithm(value, (list) => list.Reverse());
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 2:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAlgorithm(value, (list) => list.SwapFirstAndLast());
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 3:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAlgorithm(value, (list) => list.UniqueElementsCount());
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 4:
                {
                    ConsoleHelper.ExecuteOneLinkedListAlgorithm(value, (list) => list.DeleteSecondRepeatNumber());
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 5:
                {
                    ConsoleHelper.ExecuteOneLinkedListAndTargetAlgorithm(value, (list, target) => list.InsertCopyListAfter(target));
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 6:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAndElementAlgorithm(value, (list, element) => list.InsertElementOrder(element));
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 7:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAndElementAlgorithm(value, (list, element) => list.DeleteAllNumbers(element));
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 8:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAndTwoElementAlgorithm(value, (list, target, element) => list.InsertBefore(target, element));
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 9:
                {
                    ConsoleHelper.ExecuteTwoLinkedListAlgorithm(value, (list1, list2) => list1.AddLinkedList(list2));
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 10:
                {
                    ConsoleHelper.ExecuteReturnTwoDuplexLinkedListAlgorithm(value, (list, target) => list.SplitIntoTwo(target));
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }

                case 11:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAlgorithm(value, (list) => list.DoublingList());
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }
                case 12:
                {
                    ConsoleHelper.ExecuteOneDuplexLinkedListAndTwoElementAlgorithm(value, (list, index1, index2) => list.SwapElement(index1, index2), true);
                    ConsoleHelper.ExecuteReturn(AlgorithmsList, MainPage);
                    break;
                }
                case 13:
                {
                    System.Console.Clear();
                    MainPage();
                    break;
                }
            }
        }

        /// <summary> Страница Приводимых примеров алгоритмов </summary>
        public static void ExamplePage()
        {
            System.Console.WriteLine(
@"Примеры. Динамические структуры
--------------------------------------------------------------------------------------
1. BFS. Queue
2. Word reverse. Stack
3. DFS. Tree 
4. History. List
5. Выйти в главное меню.
--------------------------------------------------------------------------------------");
            var value = 0;
            while (value is not (1 or 2 or 3 or 4 or 5))
            {
                var top = System.Console.GetCursorPosition().Top;
                var left = System.Console.GetCursorPosition().Left;
                System.Console.Write("Введите порядковый номер: ");
                _ = int.TryParse(System.Console.ReadLine(), out value);
                System.Console.SetCursorPosition(System.Console.GetCursorPosition().Left, System.Console.GetCursorPosition().Top - 1);
                System.Console.Write(new string(' ', System.Console.BufferWidth));
                System.Console.SetCursorPosition(left, top);
            }

            switch (value)
            {
                case 1:
                {
                    BFS.BFS_execution();
                    ConsoleHelper.ExecuteReturn(ExamplePage, MainPage);
                    break;
                }
                case 2:
                {
                    ConsoleHelper.ExecuteAlgorithm(value, (sentence) => sentence.ReversingWords(), "Введите предложение: ");
                    ConsoleHelper.ExecuteReturn(ExamplePage, MainPage);
                    break;
                }
                case 3:
                {
                    DFS.DFS_execution();
                    ConsoleHelper.ExecuteReturn(ExamplePage, MainPage);
                    break;
                }
                case 4:
                {
                    History.History_Execution(new History());
                    ConsoleHelper.ExecuteReturn(ExamplePage, MainPage);
                    break;
                }
                case 5:
                {
                    System.Console.Clear();
                    MainPage();
                    break;
                }
            }
        }

        /// <summary> Главная страница </summary>
        public static void MainPage()
        {
            System.Console.WriteLine(
@"-----------------------------
1. Стеки.
2. Очередь.
3. Динам структуры.
4. Алгоритмы со списками.
-----------------------------");
            var value = 0;
            while (value is not (1 or 2 or 3 or 4))
            {
                var top = System.Console.GetCursorPosition().Top;
                var left = System.Console.GetCursorPosition().Left;
                System.Console.Write("Введите порядковый номер: ");
                _ = int.TryParse(System.Console.ReadLine(), out value);
                System.Console.SetCursorPosition(System.Console.GetCursorPosition().Left,
                                                    System.Console.GetCursorPosition().Top - 1);
                System.Console.Write(new string(' ', System.Console.BufferWidth));
                System.Console.SetCursorPosition(left, top);
            }

            switch (value)
            {
                case 1:
                {
                    System.Console.Clear();
                    StackPage();
                    break;
                }
                case 2:
                {
                    System.Console.Clear();
                    QueuePage();
                    break;
                }
                case 3:
                {
                    System.Console.Clear();
                    ExamplePage();
                    break;
                }
                case 4:
                {
                    System.Console.Clear();
                    AlgorithmsList();
                    break;
                }
            }
        }
    }
}
