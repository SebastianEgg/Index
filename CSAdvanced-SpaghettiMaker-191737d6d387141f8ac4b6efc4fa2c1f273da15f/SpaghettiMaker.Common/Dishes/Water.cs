namespace SpaghettiMaker.Common.Dishes;

public class Water : DishObject
{
    public bool IsPoured { get; private set; }

    public static Task<Water> PourAsync()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Pouring water...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Water is ready");
            return new Water()
            {
                IsPoured = true,
            };
        });
    }
}
