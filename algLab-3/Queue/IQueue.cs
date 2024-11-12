namespace algLab_3.Queue
{
    public interface IQueue<T>
    {
        /// <summary> добавление в очередь </summary>
        /// <param name="element"> Элемент </param>
        void Enqueue(T element);

        /// <summary> удаление из очереди </summary>
        T Dequeue();

        /// <summary> первый элемент </summary>
        T First();

        /// <summary> последний элемент </summary>
        T Last();

        /// <summary> Проверить пустой ли стек </summary>
        bool IsEmpty();
    }
}
