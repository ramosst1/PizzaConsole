namespace PizzaConsole.Pizza
{
    public interface IToppingAggregate
    {
        int NumberTimesOrdered { get; }
        string ToppingName { get; }
    }
}