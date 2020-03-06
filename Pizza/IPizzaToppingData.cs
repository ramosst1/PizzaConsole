using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaConsole.Pizza
{
    public interface IPizzaToppingData 
    {

        string[] Toppings { get; set; }
        List<IPizzaToppingData> GetData();
        string ToppingToStringList();

    }
}
