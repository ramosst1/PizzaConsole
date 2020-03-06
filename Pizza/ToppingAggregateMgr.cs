using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaConsole.Pizza
{
    public class ToppingAggregateMgr
    {
        private IPizzaToppingData _PizzaTopping;

        public ToppingAggregateMgr(IPizzaToppingData aPizzaTopping)
        {
            _PizzaTopping = aPizzaTopping;
        }

        public List<IToppingAggregate> GetTopPizzaCombinations(int maxRows)
        {

            var ToppingList = new List<IToppingAggregate>();

            try
            {

                var PizzaToppingList = _PizzaTopping.GetData();

                var PizzaToppingsConsolidated = ConsolidateToppingCombination(PizzaToppingList);

                var PizzAgregList = AggregrateToppings(PizzaToppingsConsolidated)
                        .OrderByDescending(aItem => aItem.NumberTimesOrdered)
                        .Take(maxRows);

                ToppingList.AddRange(PizzAgregList);

            }
            catch (Exception e)
            {
                throw new Exception("Unable to aggregate the Pizza toppings");
            }

            return ToppingList;
        }

        private static List<string> ConsolidateToppingCombination(List<IPizzaToppingData> pizzaTopping)
        {

            var ToppingList = new List<string>();

            pizzaTopping
                .Select(aItem => aItem.ToppingToStringList())
                .ToList()
                .ForEach(delegate (string aTopping) {
                    ToppingList.Add(aTopping);
                });

            return ToppingList;
        }

        private List<IToppingAggregate> AggregrateToppings(List<string> pizzaToppingList)
        {

            var ToppingAggregates = new List<ToppingAggregate>();

            pizzaToppingList.Distinct().ToList().ForEach(delegate (string topping) {

                var PizzaTopAggreg = new ToppingAggregate()
                {
                    ToppingName = topping,
                    NumberTimesOrdered = pizzaToppingList.Where(aItem => aItem.Equals(topping, StringComparison.CurrentCultureIgnoreCase)).Count()
                };

                ToppingAggregates.Add(PizzaTopAggreg);
            });

            return ToppingAggregates.Cast<IToppingAggregate>().ToList();
        }

    }
}
