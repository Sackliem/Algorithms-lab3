using System.Collections;

namespace algLab_3.Stack
{
    /// <summary> Класс структуры данных стек </summary>
    /// <typeparam name="T"> Тип элементов стека </typeparam>
    public class Stack<T> : IStack<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        /// <summary> Класс узел </summary>
        /// <typeparam name="T"> Тип элемента стека </typeparam>
        private class Node<T>
        {
            /// <summary> Значение элемента стека </summary>
            public T Value { get; }

            /// <summary> Вершина стека </summary>
            public Node<T> Top { get; init; }

            /// <summary> Инициализировать узел </summary>
            /// <param name="value"> Значение элемента стека </param>
            public Node(T value)
            {
                Value = value;
            }
        }

        /// <summary> Вершина стека </summary>
        private Node<T>? _top;
        /// <summary> Размер стека </summary>
        private int _size;

        /// <summary> Число элементов стека </summary>
        public int Count => _size;

        /// <summary> Добавить элемент на вершину стека </summary>
        /// <param name="element"> Добавляемый элемент </param>
        public void Push(T element)
        {
            var newNode = new Node<T>(element)
            {
                Top = _top
            };
            _top = newNode;
            _size++;
        }

        /// <summary> Извлечь элемент из вершины стека </summary>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст, нельзя извлечь элемент.");
            }

            var elem = _top.Value;
            _top = _top.Top;
            _size--;
            return elem;
        }

        /// <summary> Получить верхний элемент стека </summary>
        public T Top()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст, нельзя извлечь элемент.");
            }

            return _top.Value;
        }

        /// <summary> Проверить пустой ли стек </summary>
        public bool IsEmpty()
        {
            return _top == null;
        }

        public Stack<T>.Enumerator GetEnumerator() => new Stack<T>.Enumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>) new Stack<T>.Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new Stack<T>.Enumerator(this);

        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private readonly Stack<T> _stack;
            private int _index;
            private Node<T> _currentNode;
            private T _currentElement;

            internal Enumerator(Stack<T> stack)
            {
                _stack = stack;
                _index = -2;
                _currentNode = null;
                _currentElement = default (T);
            }

            public bool MoveNext()
            {
                if (_index == -2)
                {
                    _index = _stack._size - 1;
                    var flag = _index >= 0;
                    if (flag)
                    {
                        _currentNode = _stack._top;
                        _currentElement = _currentNode.Value;
                    }

                    return flag;
                }

                if (_index == -1)
                {
                    return false;
                }

                var flag2 = --_index >= 0;
                _currentNode = !flag2 ? null : _currentNode.Top;
                _currentElement = !flag2 ? default(T) : _currentNode.Value;
                return flag2;
            }

            public void Reset()
            {
                _index = -2;
                _currentElement = default (T);
            }

            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        throw new InvalidOperationException("Стек пуст.");
                    }

                    return _currentElement;
                }
            }

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                _index = -1;
            }
        }
    }
}
