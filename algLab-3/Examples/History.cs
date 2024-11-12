using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algLab_3.Examples
{

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    internal class History
    {
        private Node<string> head;
        private Node<string> current;

        public void Visit(string url)
        {
            var newNode = new Node<string>(url);

            if (head == null)
            {
                head = newNode; // Если это первая страница, устанавливаем её как голову 
            }
            else
            {
                // Если есть текущая страница, устанавливаем её как предыдущую 
                current.Next = newNode;
                newNode.Previous = current;
            }

            current = newNode; // Перемещаем текущий указатель на новую страницу 
        }

        public string Back()
        {
            if (current == null || current.Previous == null)
                throw new InvalidOperationException("Нет предыдущей страницы.");

            current = current.Previous; // Возвращаемся к предыдущей странице 
            return current.Value;
        }

        public string CurrentUrl()
        {
            return current?.Value ?? "Нет текущей страницы.";
        }

        public List<string> GetHistory()
        {
            List<string> history = new List<string>();
            Node<string> temp = head;

            while (temp != null)
            {
                history.Add(temp.Value);
                temp = temp.Next;
            }

            return history;
        }

        public static void History_Execution(History history)
        {
            // Генерация тестовых данных 
            history.Visit("https://example.com");
            history.Visit("https://example.com/page1");
            history.Visit("https://example.com/page2");

            Console.WriteLine("Текущая страница: " + history.CurrentUrl());

            Console.WriteLine("Возврат назад: " + history.Back());
            Console.WriteLine("Текущая страница: " + history.CurrentUrl());

            Console.WriteLine("Возврат назад: " + history.Back());
            Console.WriteLine("Текущая страница: " + history.CurrentUrl());

            // Печать всей истории 
            Console.WriteLine("История посещенных страниц:");
            foreach (var url in history.GetHistory())
            {
                Console.WriteLine(url);
            }
        }
    }


}
