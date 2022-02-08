namespace SpaghettiMaker.Common.Dishes;

public class Redwine : DishObject
{
    public bool IsPoured { get; private set; }

    public static Task<Redwine> PourAsync()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Pouring redwine...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Redwine is ready!");
            return new Redwine()
            {
                IsPoured = true,
            };
        });
    }
}

