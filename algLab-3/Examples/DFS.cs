using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algLab_3.Examples
{
    public class TreeNode
    {
        public int Value;
        public List<TreeNode> Children;

        public TreeNode(int value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }

    internal class TreeGenerator
    {
        public static TreeNode GenerateTree()
        {
            Random rand = new Random();
            int nodeCount;

            Console.WriteLine("Задать размер дерева самостоятельно?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("Введите размер:");
                nodeCount = Convert.ToInt32(Console.ReadLine());
                if (nodeCount < 3)
                {
                    Console.WriteLine("Вы ввели некорректный размер дерева. Программа автоматически установила размер.");
                    nodeCount = rand.Next(3, 5);
                }
            }
            else
            {
                nodeCount = rand.Next(3, 5);
            }

            // Создаем корень дерева
            TreeNode root = new TreeNode(1);
            List<TreeNode> nodes = new List<TreeNode> { root };

            for (int i = 2; i <= nodeCount; i++)
            {
                TreeNode newNode = new TreeNode(i);
                TreeNode parent = nodes[rand.Next(nodes.Count)];
                parent.AddChild(newNode);
                nodes.Add(newNode);
            }

            Console.WriteLine("Сгенерировано дерево с {0} узлами.", nodeCount);
            return root;
        }
    }

    internal class DFS
    {
        public static void DFS_execution()
        {

            TreeNode root = TreeGenerator.GenerateTree();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            Console.WriteLine("Начинаем обход дерева с корневого узла: {0}", root.Value);

            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                Console.WriteLine("Посетили узел {0}", currentNode.Value);

                for (int i = currentNode.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(currentNode.Children[i]);
                }
            }
        }
    }
}
