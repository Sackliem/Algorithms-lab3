using static algLab_3.Stack.Task4;

namespace algLab_3.Stack
{
    /// <summary> Часть 1. Задание 4. </summary>
    public class Task5
    {
        /// <summary> Преобразовать инфиксную запись в постфиксную </summary>
        /// <param name="str"> Выражение в инфиксной форме </param>
        public static string InfixToPrefix(string str)
        {
            var commands = str.Split(' ');
            var operatorsStack = new Stack<string>();
            var numberQueue = new Queue<string>();
            foreach (var item in commands)
            {
                IOperation oper;
                if (!CheckIsOperator(item, out oper))
                {
                    numberQueue.Enqueue(item);
                }

                if (CheckIsOperator(item, out oper))
                {
                    if (item == "(")
                    {
                        operatorsStack.Push(item);
                    }
                    else if (item == ")")
                    {
                        var bracket = operatorsStack.Pop();
                        while (bracket != "(")
                        {
                            numberQueue.Enqueue(bracket);
                            bracket = operatorsStack.Pop();
                        }
                    }
                    else
                    {
                        if (!operatorsStack.IsEmpty())
                        {
                            if (GetPriority(item) <= GetPriority(operatorsStack.Top()))
                            {
                                numberQueue.Enqueue(operatorsStack.Pop());
                            }
                        }
                        operatorsStack.Push(item);
                    }
                }
            }

            while (operatorsStack.Count > 0)
            {
                numberQueue.Enqueue(operatorsStack.Pop());
            }
            
            var result = string.Join(' ', numberQueue);
            return result;
        }

        public static int GetPriority(string item)
        {
            return item switch
            {
                "(" => 0,
                ")" => 1,
                "+" => 2,
                "-" => 2,
                "*" => 3,
                "/" => 3,
                _ => 4
            };
        }

        /// <summary> Проверить является ли элемент выражения оператором </summary>
        /// <param name="item"> Элемент выражения </param>
        /// <param name="result"> Полученный оператор </param>
        public static bool CheckIsOperator(string item, out IOperation result)
        {
            switch (item.ToLower())
            {
                case "+":
                    result = new Addition();
                    break;
                case "-":
                    result = new Subtraction();
                    break;
                case "*":
                    result = new Multiplication();
                    break;
                case "/":
                    result = new Dividing();
                    break;
                case "^":
                    result = new ElevationToRank();
                    break;
                case "ln":
                    result = new NaturalLagorithm();
                    break;
                case "cos":
                    result = new Cos();
                    break;
                case "sin":
                    result = new Sin();
                    break;
                case "sqrt":
                    result = new Sqrt();
                    break;
                case "(":
                    result = null;
                    break;
                case ")":
                    result = null;
                    break;
                default:
                    result = null;
                    return false;
            }

            return true;
        }
    }
}
