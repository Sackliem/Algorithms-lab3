using System.Collections;

namespace algLab_3.Lists
{
    /// <summary> Циклический связный список </summary>
    /// <typeparam name="T"> Тип элементов списка </typeparam>
    public class CyclicDuplexLinkedList<T> : IEnumerable, IEnumerable<T>, ICollection<T>
    {
        /// <summary> Головной элемент списка </summary>
        public DuplexLinkedList<T>.Node<T> Head { get; private set; }
        /// <summary> Количество элементов в списке </summary>
        public int Count { get; private set; }

        public CyclicDuplexLinkedList() {}

        /// <summary> Инициализация списка с начальным элементом </summary>
        /// <param name="item"> Элемент данных списка </param>
        public CyclicDuplexLinkedList(T item)
        {
            var node = new DuplexLinkedList<T>.Node<T>(item);
            SetHead(node);
        }

        /// <summary> Инициализировать список с начальной коллекцией </summary>
        /// <param name="collection"> Начальная коллекция </param>
        public CyclicDuplexLinkedList(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            foreach (var obj in collection)
                Add(obj);
        }

        /// <summary> Добавить элемент данных в список </summary>
        /// <param name="item"> Элемент данных списка </param>
        public void Add(T item)
        {
            var node = new DuplexLinkedList<T>.Node<T>(item);
            Add(node);
        }

        /// <summary> Добавить элемент в список </summary>
        /// <param name="node"> Элемент списка </param>
        public void Add(DuplexLinkedList<T>.Node<T> node)
        {
            if (IsEmpty)
            {
                SetHead(node);
                return;
            }

            node.Next = Head;
            node.Prev = Head.Prev;
            Head.Prev.Next = node;
            Head.Prev = node;
            Count++;
        }

        /// <summary> Удалить первое вхождение данных в список </summary>
        /// <param name="data"> Удаляемые данные </param>
        public void Delete(T data)
        {
            if (Head.Data.Equals(data))
            {
                Head.Next.Prev = Head.Prev;
                Head.Prev.Next = Head.Next;
                Count--;
                Head = Head.Next;
                return;
            }

            var current = Head;
            for (var i = Count; i > 0; i--)
            {
                if (current != null && current.Data.Equals(data))
                {
                    current.Next.Prev = current.Prev;
                    current.Prev.Next = current.Next;
                    Count--;
                }

                current = current.Next;
            }
        }

        /// <summary> Установить головной и последний элемент списка </summary>
        /// <param name="node"> Элемент списка </param>
        private void SetHead(DuplexLinkedList<T>.Node<T> node)
        {
            Head = node;
            Head.Next = Head;
            Head.Prev = Head;
            Count = 1;
        }

        /// <summary> Пустой ли список </summary>
        public bool IsEmpty => Count == 0;

        /// <summary> Очистка списка </summary>
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        /// <summary> Перечислитель, осуществляет итерационный переход по списку </summary>
        /// <returns> IEnumerator — проход по коллекции </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary> Перечислитель, осуществляет итерационный переход по списку </summary>
        /// <returns> IEnumerator — проход по коллекции </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary> Перечислитель, осуществляет итерационный переход по списку </summary>
        /// <returns> IEnumerator — проход по коллекции </returns>
        private IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            for (var i = 0; i < Count; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
