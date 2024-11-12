namespace algLab_3.Lists
{
    public static class Extensions
    {
        /// <summary> Имя файла с тестовыми данными </summary>
        public static string FileNameTestData { get; private set; } = "input";

        /// <summary>
        /// 6. Написать функцию, которая вставляет в непустой список L, элементы которого упорядочены по не убыванию, новый элемент Е так, чтобы сохранилась упорядоченность.
        /// Часть 4. Задание 6.
        /// </summary>
        /// <param name="list"> Упорядоченный не по убыванию список </param>
        /// <param name="element"> Добавляемы элемент </param>
        public static void InsertElementOrder(this Lists.DuplexLinkedList<int> list, int element)
        {
            if (list.Count == 0) list.Add(element);
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] >= element)
                {
                    list.Add(element, i);
                    return;
                }
            }
            list.AddLast(element);
            

            foreach(var i in list)
                Console.Write(i + " ");
        }

        /// <summary> Чтение из файла списков для объединения (Часть 4. Задание 9.) </summary>
        public static LinkedList<int> GetListFromFileTask9()
        {
            var lines = File.ReadAllLines($"{FileNameTestData}.txt");
            var list1Item = lines[0].Split(' ');
            var list2Item = lines[1].Split(' ');
            var list1 = new LinkedList<int>();
            var list2 = new LinkedList<int>();
            foreach (var item in list1Item)
            {
                list1.Add(int.Parse(item));
            }
            foreach (var item in list2Item)
            {
                list2.Add(int.Parse(item));
            }

            list1.AddLinkedList(list2);
            return list1;
        }
    }
}
