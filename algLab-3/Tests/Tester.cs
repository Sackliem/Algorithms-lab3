using System.Text;

namespace algLab_3.Tests
{
    /// <summary> Класс тестирования </summary>
    public class Tester
    {
        /// <summary> Вектор времени </summary>
        private readonly List<(int, double)> _timeVector;
        /// <summary> Начальное значение: количество операций </summary>
        private int _start;
        /// <summary> Конечное значение: количество операций </summary>
        private int _end;
        /// <summary> Шаг: количество операций </summary>
        private int _step;

        /// <summary> Имя файла с тестовыми данными </summary>
        public static string FileNameTestData { get; private set; } = "input";

        /// <summary> Паттерн для тестирования по умолчанию </summary>
        public static string PatternForTestingDefault { get; private set; } = "132"; // push top pop

        /// <summary> Получить вектор времени </summary>
        /// <returns> Словарь, где key - количество операций, value - время в миллисекундах </returns>
        public List<(int, double)> GetTimeVector() => _timeVector;

        /// <summary> Инициализация тестера </summary>
        /// <param name="start"> Начальное значение: количество операций </param>
        /// <param name="end"> Конечное значение: количество операций </param>
        /// <param name="step"> Шаг: количество операций </param>
        public Tester(int start, int end, int step)
        {
            _timeVector = new List<(int, double)>();
            Init(start, end, step);
        }

        /// <summary> Инициализация тестера </summary>
        /// <param name="end"> Конечное значение: количество операций </param>
        /// <param name="step"> Шаг: количество операций </param>
        public Tester(int end = 25, int step = 1)
        {
            _timeVector = new List<(int, double)>();
            Init(1, end, step);
        }

        private void Init(int start, int end, int step)
        {
            _start = start;
            _end = end;
            _step = step;
        }

        /// <summary> Тестировать обычным способом (число операций различно) </summary>
        /// <param name="newData"> Генерировать ли новые тестовые данные</param>
        public void Testing(TypeTest type, bool newData = true)
        {
            if (newData || !File.Exists($"{FileNameTestData}.txt")) GenerateTestFile();
            var lines = File.ReadAllLines($"{FileNameTestData}.txt");
            var index = _start;
            foreach (var l in lines)
            {
                Console.WriteLine($"Размер набора операций: {index}.");
                switch (type)
                {
                    case TypeTest.Stack:
                        _timeVector.Add((index, Stack.Task2.ParsingAndExecutingOperations(new Stack.Stack<object>(), l)));
                        break;
                    case TypeTest.Queue:
                        _timeVector.Add((index, Queue.Task2Queue.ParsingAndExecutingOperations(new Queue.Queue<object>(), l)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }

                index += _step;
            }
        }

        public void TestingWithFixedLength(TypeTest type, string pattern, int size)
        {
            var str = GenerateInputString(size, pattern).ToString();
            switch (type)
            {
                case TypeTest.Stack:
                    _timeVector.Add((size, Stack.Task2.ParsingAndExecutingOperations(new Stack.Stack<object>(), str)));
                    break;
                case TypeTest.Queue:
                    _timeVector.Add((size, Queue.Task2Queue.ParsingAndExecutingOperations(new Queue.Queue<object>(), str)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary> Установить имя файла тестовых данных </summary>
        /// <param name="fileName"> Новое имя файла </param>
        public static void SetFileNameTestData(string fileName)
        {
            FileNameTestData = fileName;
        }

        /// <summary> Генерировать входную строку </summary>
        /// <param name="size"> Количество операций </param>
        /// <param name="pattern"> Паттерн для тестирования, по умолчанию (push, top, pop) </param>
        private static StringBuilder GenerateInputString(int size = 5, string? pattern = null)
        {
            var sb = new StringBuilder();
            pattern ??= PatternForTestingDefault;
            for (var i = 0; i < size; i++)
            {
                var item = pattern[i % pattern.Length];
                if (item == '1')
                {
                    sb.Append(item);
                    sb.Append(",12345");
                    sb.Append(' ');
                }
                else
                {
                    sb.Append(item);
                    sb.Append(' ');
                }
            }

            return sb;
        }

        /// <summary> Генерировать тестовый файл </summary>
        /// <param name="end"> Конечное значение: количество операций </param>
        /// <param name="step"> Шаг: количество операций </param>
        public void GenerateTestFile(int end, int step = 1)
        {
            Init(1, end, step);
            GenerateTestFile();
        }

        /// <summary> Генерировать тестовый файл </summary>
        /// <param name="start"> Начальное значение: количество операций </param>
        /// <param name="end"> Конечное значение: количество операций </param>
        /// <param name="step"> Шаг: количество операций </param>
        public void GenerateTestFile(int start, int end, int step = 1)
        {
            Init(start, end, step);
            GenerateTestFile();
        }

        /// <summary> Генерировать тестовый файл </summary>
        /// <param name="pattern"> Паттерн для тестирования </param>
        public void GenerateTestFile(string? pattern = null)
        {
            var fs = new FileStream($"{FileNameTestData}.txt", FileMode.Create);
            using var w = new StreamWriter(fs, Encoding.UTF8);
            for (var i = _start; i < _end + 1; i += _step)
            {
                w.WriteLine(GenerateInputString(i, pattern));
            }
        }
    }
}
