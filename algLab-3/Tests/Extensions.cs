using System.Text;

namespace algLab_3.Tests
{
    /// <summary> Класс расширения для тестера </summary>
    public static class Extensions
    {
        /// <summary> Запись в CSV файл </summary>
        /// <param name="vector"> Вектор для записи </param>
        /// <param name="step"> Шаг </param>
        /// <param name="path"> Путь </param>
        public static void WriteCsvFile<T>(this List<(int, T)> vector, int step, string path = "result.csv")
        {
            var csv = new StringBuilder();
            for (var i = 1; i < vector.Count + 1; i += step)
            {
                csv.Append($"{i};{vector[i]}");
                csv.Append(Environment.NewLine);
            }
            File.WriteAllText(path, csv.ToString());
        }

        /// <summary> Запись в CSV файл </summary>
        /// <param name="vector"> Вектор для записи </param>
        /// <param name="path"> Путь </param>
        public static void WriteCsvFile<T>(this List<(int, T)> vector, string path = "result.csv")
        {
            var csv = new StringBuilder();
            foreach (var item in vector)
            {
                csv.Append($"{item.Item1};{item.Item2}");
                csv.Append(Environment.NewLine);
            }
            File.WriteAllText(path, csv.ToString());
        }
    }
}
