namespace algLab_3.Queue
{
    /// <summary> Класс расширений </summary>
    public static class Extension
    {
        /// <summary> Печать элементов стека в консоль </summary>
        public static void Print<T>(this Queue<T> queue)
        {
            foreach (var element in queue)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
