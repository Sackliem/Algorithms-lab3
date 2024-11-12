using System.Text;

namespace algLab_3.Examples
{
    public class Node
    {
        public char data;
        public Node left, right;
        public Node(char data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
    public class ExpressionTree
    {
        public static bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '^';
        }

        public static Node GetExpressionTree(String postfix)
        {
            var stack = new Stack.Stack<Node>();
            Node t1, t2, temp;

            for (var i = 0; i < postfix.Length; i++)
            {
                if (!IsOperator(postfix[i]))
                {
                    temp = new Node(postfix[i]);
                    stack.Push(temp);
                }
                else
                {
                    temp = new Node(postfix[i]);

                    t1 = stack.Pop();
                    t2 = stack.Pop();

                    temp.left = t2;
                    temp.right = t1;

                    stack.Push(temp);
                }
            }
            temp = stack.Pop();
            return temp;
        }
        public static StringBuilder Inorder(Node root, StringBuilder result)
        {
            if (root == null) return result;
            Inorder(root.left, result);
            result.Append(root.data);
            Inorder(root.right, result);
            return result;
        }

        public static void ShowExpression(string postfix)
        {
            var r = GetExpressionTree(postfix);
            //Inorder(r);
        }
    }
}
