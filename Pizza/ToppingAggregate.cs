using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaConsole.Pizza
{
    public class ToppingAggregate : IToppingAggregate
    {

        public string ToppingName { get; internal protected set; }

        public int NumberTimesOrdered { get; internal protected set; }


    }

}
