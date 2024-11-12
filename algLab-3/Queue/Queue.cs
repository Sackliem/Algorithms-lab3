using System.Collections;

namespace algLab_3.Queue
{
    /// <summary> Класс очереди </summary>
    /// <typeparam name="T"> Тип элементов очереди </typeparam>
    public class Queue<T> : IEnumerable<T>, IQueue<T>, IEnumerable, IReadOnlyCollection<T>
    {
        /// <summary> Класс элемент очереди </summary>
        /// <typeparam name="T"> Тип данных очереди </typeparam>
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }


        private int _size = 0;
        /// <summary> Головной/первый элемент </summary>
        private Node<T> _head;
        /// <summary> Последний/хвостовой элемент </summary>
        private Node<T> _tail;
        /// <summary> Количество элементов очереди </summary>
        public int Count => _size;

        /// <summary> Проверить очередь на пустоту </summary>
        public bool IsEmpty() => _size == 0;

        /// <summary> Добавление данных в очередь </summary>
        /// <param name="data"> Добавляемые данные </param>
        public void Enqueue(T data)
        {
            var node = new Node<T>(data);
            var tempNode = _tail;
            _tail = node;
            if (_size == 0)
                _head = _tail;
            else
                tempNode.Next = _tail;
            _size++;
        }

        /// <summary> Извлечь данные из очереди </summary>
        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException();
            var output = _head.Data;
            _head = _head.Next;
            _size--;
            return output;
        }

        /// <summary> Получить первый элемент </summary>
        T IQueue<T>.First()
        {
            if (IsEmpty())
               throw new InvalidOperationException();
            return _head.Data;
        }

        /// <summary> Получить последний элемент </summary>
        T IQueue<T>.Last()
        {
             if (IsEmpty())
                 throw new InvalidOperationException();
             return _tail.Data;
        }

        /// <summary> Очистить очередь </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        /// <summary> Проверить содержится ли в очереди элемент </summary>
        /// <param name="data"> Проверяемый элемент </param>
        public bool Contains(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

