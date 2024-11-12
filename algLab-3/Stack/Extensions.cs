namespace algLab_3.Stack
{
    /// <summary> Класс расширений </summary>
    public static class Extensions
    {
        /// <summary> Печать элементов стека в консоль </summary>
        public static void Print<T>(this Stack<T> stack)
        {
            foreach (var element in stack)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
