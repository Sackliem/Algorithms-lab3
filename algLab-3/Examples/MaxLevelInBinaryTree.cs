using algLab_3.Examples;

namespace algLab_3.Examples
{
    public class MaxLevelInBinaryTree
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }
        }

        public static int MaxLevelSum(Node root)
        {
            if (root == null)
                return 0;

            var result = root.data;

            var queue = new Queue.Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;

                var sum = 0;
                while (count-- > 0)
                {

                    var temp = queue.Dequeue();

                    sum = sum + temp.data;

                    if (temp.left != null)
                        queue.Enqueue(temp.left);
                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }

                result = Math.Max(sum, result);
            }

            return result;
        }

        public static Node MakeBinaryTree(int[] data)
        {
            return AddNodeThree(data, 0);
        }

        public static Node AddNodeThree(int[] data, int index)
        {
            Node root = null;
            if (index < data.Length) 
            {
                root = new Node(data[index])
                {
                    left = AddNodeThree(data, 2 * index + 1),
                    right = AddNodeThree(data, 2 * index + 2)
                };
            }
            return root;
        }

        public static void ShowMaxLevel()
        {
            var root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.right = new Node(8);
            root.right.right.left = new Node(6);
            root.right.right.right = new Node(7);

            Console.WriteLine("Максимальная сумма равна " + MaxLevelSum(root));
        }
    }
}
