using System;
using PizzaConsole.Pizza;
using PizzaConsole.Util.Messages;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace PizzaConsole
{
    class Program
    {

        private const int _TopPizzaMaxRows = 20;
        private static IAppHostSingleton _AppHostSingleton; 

        static void Main(string[] args)
        {

            try
            {

                InitializeDepedencyInjections();

                ConsoleMessage.DisplayStartMessage();



                IPizzaToppingData APizzaToppingData = new PizzaToppingDataJson(_AppHostSingleton);

                var AToppingAggregateMgr = new ToppingAggregateMgr(APizzaToppingData);

                List <IToppingAggregate> TopPizzaCombinations = AToppingAggregateMgr.GetTopPizzaCombinations(_TopPizzaMaxRows);

                var PizzaDisplayText = TopPizzaCombinations
                        .Select(aItem => $"The toppings {aItem.ToppingName} was ordered {aItem.NumberTimesOrdered} times.");

                ConsoleMessage.DisplayMessage(PizzaDisplayText);

                ConsoleMessage.DisplayEndMessage();

            }
            catch (Exception e) {
                ConsoleMessage.ErrorMessage("The Pizza Aggregate failed.");
            }

        }

        private static void InitializeDepedencyInjections() {

            var serviceProvider = new ServiceCollection()
            .AddSingleton<IAppHostSingleton, AppHostSingleton>()
            .BuildServiceProvider();

            _AppHostSingleton = serviceProvider.GetService<IAppHostSingleton>();

        }

    }
}
