namespace algLab_3.Examples
{
    public static class DeleteDuplicateFromLinkedList
    {
        public static void PrintList<T>(this Lists.LinkedList<T>.Node<T> node)
        {
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }
        }
        public static void ShowResult(string[] elementsArray)
        {

            var myInts = Array.ConvertAll(elementsArray, s => Convert.ToInt32(s));

            var list = new Lists.LinkedList<int>(myInts) { };

            Console.WriteLine("Связный лист до удаления дубликатов: ");
            list.Head.PrintList();

            // Часть 3.
            list.RemoveDuplicates();
            Console.WriteLine("");
            Console.WriteLine("Связный лист после удаления дубликатов: ");
            list.Head.PrintList();
        }
    }
}
