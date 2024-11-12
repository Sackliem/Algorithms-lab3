namespace algLab_3.Stack
{
    public interface IStack<T>
    {
        /// <summary> Добавление элемента в стек </summary>
        /// <param name="element"> Элемент </param>
        void Push(T element);

        /// <summary> Извлечь элемент </summary>
        T Pop();

        /// <summary> Получить верхний элемент </summary>
        T Top();

        /// <summary> Проверить пустой ли стек </summary>
        bool IsEmpty();
    }
}
