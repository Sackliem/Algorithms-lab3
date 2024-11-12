using System.Text;

namespace algLab_3.Examples
{
    public static class ReverseWords
    {
        public static string ReversingWords(this string str)
        {
            var stack = new Stack.Stack<char>();
            var result = new StringBuilder();

            foreach (var item in str)
            {
                if (item != ' ') stack.Push(item);

                else
                {
                    while (stack.Count > 0) result.Append(stack.Pop());
                    //Console.Write(stack.Pop());
                    result.Append(' ');
                    //Console.Write(" ");
                }
            }

            while (stack.Count > 0) result.Append(stack.Pop());
                //Console.Write(stack.Pop());
            return result.ToString();
        }

        //public static void ShowResult(string word)
        //{
        //    ReversingWords(word);
        //}
    }
}

