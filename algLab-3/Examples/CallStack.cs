using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algLab_3.Examples
{

    class CallStack
    {
        private Stack<string> stack = new Stack<string>();

        // Вызов функции
        public void CallFunction(string functionName)
        {
            stack.Push(functionName);
            Console.WriteLine($"Called: {functionName}");
        }

        // Завершение функции
        public void ReturnFunction()
        {
            if (stack.Count > 0)
            {
                string finishedFunction = stack.Pop();
                Console.WriteLine($"Returned from: {finishedFunction}");
            }
            else
            {
                Console.WriteLine("No functions left to return from.");
            }
        }

        // Вывод текущего состояния стека вызовов
        public void ShowStack()
        {
            Console.WriteLine("\nCurrent Call Stack:");
            if (stack.Count == 0)
            {
                Console.WriteLine("  (empty)");
            }
            else
            {
                foreach (var func in stack)
                {
                    Console.WriteLine($"  {func}");
                }
            }
            Console.WriteLine();
        }
    }

    class CallStack_exec
    {
        public static void CallStack_execution()
        {
            CallStack callStack = new CallStack();

            // Имитация вызовов функций
            callStack.CallFunction("Main");
            callStack.CallFunction("FunctionA");
            callStack.CallFunction("FunctionB");
            callStack.ShowStack();

            // Завершение функций
            callStack.ReturnFunction();
            callStack.ShowStack();

            callStack.ReturnFunction();
            callStack.ShowStack();

            callStack.ReturnFunction();
            callStack.ShowStack();

            // Попытка возврата из пустого стека
            callStack.ReturnFunction(); 
            callStack.ShowStack();
        }
    }
}
