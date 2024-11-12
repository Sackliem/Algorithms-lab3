using System.Diagnostics;

namespace algLab_3.Tests
{
    /// <summary> Тестирование памяти </summary>
    public class OutOfMemoryTester
    {
        private int _countChar = 524288;

        /// <summary>
        /// Количество символов в строке для добавления в коллекцию
        /// 1 символ — 2 байта;
        /// 524288 символов — 1048576 байт = 1024 Кбайт = 1 Мбайт
        /// </summary>
        public int CountChar
        {
            get => _countChar;
            set => _countChar = value;
        }

        /// <summary> Вектор памяти: key - номер операции, value — время </summary>
        private readonly Dictionary<int, long> _memoryVector;

        /// <summary> Инициализировать тестер памяти </summary>
        public OutOfMemoryTester()
        {
            _memoryVector = new Dictionary<int, long>();
        }

        /// <summary> Получить вектор памяти </summary>
        public Dictionary<int, long> GetMemoryVector() => _memoryVector;

        /// <summary> Запустить тестирование памяти </summary>
        /// <param name="oper"> Операция выполняемая над коллекцией </param>
        /// <returns> (Номер операции на которой произошла ошибка, Время в миллисекундах затраченное на выполнение операций) </returns>
        public (int, double) Testing(Action<string> oper)
        {
            var count = 1;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                while (true)
                {
                    oper(new string('*', _countChar));
                    var process = Process.GetCurrentProcess();
                    _memoryVector.Add(count, process.WorkingSet64);
                    Console.WriteLine(count);
                    count++;
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("OutOfMemoryException успешно обработано.");
            }
            stopWatch.Stop();

            return (count, stopWatch.Elapsed.TotalMilliseconds);
        }
    }
}
