using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PizzaConsole.Util.Messages
{
    class ConsoleMessage
    {

        public static void DisplayStartMessage()
        {
            Console.WriteLine("Please wait while gather pizza aggregation....");
            Console.WriteLine("");
        }
        public static void DisplayEndMessage()
        {
            Console.WriteLine("The Pizza aggregation is complete. Press Enter to close.\r\r");
            Console.WriteLine("");

            Console.ReadLine();
        }

        public static void DisplayMessage(string message) {
            Console.WriteLine($"{message} \r\r");
            Console.WriteLine("");
        }

        public static void DisplayMessage(IEnumerable <string> messages)
        {

            foreach (var aMessage in messages) {
                Console.WriteLine(aMessage);
            }
        }

        public static void ErrorMessage(string errorMessage) {
            Console.WriteLine($"An error occured. {errorMessage} \r\r");
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
