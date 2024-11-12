namespace algLab_3.Stack
{
    /// <summary> Часть 1. Задание 4. </summary>
    public class Task4
    {
        /// <summary> Вычислить значение выражения </summary>
        /// <param name="str"> Выражение в постфиксной форме </param>
        /// <returns> Значение выражения </returns>
        public static double Calculate(string str)
        {
            var commands = str.Split(' ');
            var stack = new Stack<double>();
            foreach (var item in commands)
            {
                IOperation oper;
                if (!CheckIsOperator(item, out oper))
                {
                    stack.Push(double.Parse(item));
                }

                if (CheckIsOperator(item, out oper))
                {
                    var x = stack.Pop();
                    var result = 0.0;
                    if (oper is IBinaryOperation binaryOperation)
                    {
                        var y = stack.Pop();
                        result = binaryOperation.Calculate(y, x);
                        stack.Push(result);
                    }

                    if (oper is IUnaryOperation unaryOperation)
                    {
                        result = unaryOperation.Calculate(x);
                        stack.Push(result);
                    }
                }
            }

            var resultInput = Math.Round(stack.Pop(), 3);
            return resultInput;
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
                default:
                    result = null;
                    return false;
            }

            return true;
        }

        /// <summary> Интерфейс операции </summary>
        public interface IOperation
        {
            /// <summary> Имя операции </summary>
            string OperationName { get; }
        }

        /// <summary> Интерфейс бинарной операции </summary>
        public interface IBinaryOperation : IOperation
        {
            /// <summary> Вычислить </summary>
            /// <param name="x"> Первый операнд </param>
            /// <param name="y"> Второй операнд </param>
            double Calculate(double x, double y);
        }

        /// <summary> Интерфейс унарной операции </summary>
        public interface IUnaryOperation : IOperation
        {
            /// <summary> Вычислить </summary>
            /// <param name="x"> Первый операнд </param>
            double Calculate(double x);
        }

        /// <summary> Класс сложения </summary>
        public class Addition : IBinaryOperation
        {
            string IOperation.OperationName => "+";
            public double Calculate(double x, double y) => x + y;
        }

        /// <summary> Класс вычитания </summary>
        public class Subtraction : IBinaryOperation
        {
            string IOperation.OperationName => "-";
            public double Calculate(double x, double y) => x - y;
        }

        /// <summary> Класс умножения </summary>
        public class Multiplication : IBinaryOperation
        {
            string IOperation.OperationName => "*";
            public double Calculate(double x, double y) => x * y;
        }

        /// <summary> Класс деления </summary>
        public class Dividing : IBinaryOperation
        {
            string IOperation.OperationName => "/";
            public double Calculate(double x, double y) => x / y;
        }

        /// <summary> Класс возведения в степень </summary>
        public class ElevationToRank : IBinaryOperation
        {
            string IOperation.OperationName => "^";
            public double Calculate(double x, double y) => Math.Pow(x, y);
        }

        /// <summary> Класс натуральный логарифм </summary>
        public class NaturalLagorithm : IUnaryOperation
        {
            string IOperation.OperationName => "ln";
            public double Calculate(double x) => Math.Log(x, Math.E);
        }

        /// <summary> Класс косинус </summary>
        public class Cos : IUnaryOperation
        {
            string IOperation.OperationName => "cos";
            public double Calculate(double x) => Math.Cos(x);
        }

        /// <summary> Класс синус </summary>
        public class Sin : IUnaryOperation
        {
            string IOperation.OperationName => "sin";
            public double Calculate(double x) => Math.Sin(x);
        }

        /// <summary> Класс квадратный корень </summary>
        public class Sqrt : IUnaryOperation
        {
            string IOperation.OperationName => "sqrt";
            public double Calculate(double x) => Math.Sqrt(x);
        }
    }
}
