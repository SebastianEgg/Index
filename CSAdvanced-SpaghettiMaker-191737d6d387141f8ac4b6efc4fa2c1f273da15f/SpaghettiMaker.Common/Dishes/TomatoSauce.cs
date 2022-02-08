namespace SpaghettiMaker.Common.Dishes;

public class TomatoSauce : DishObject
{
    public static int MaxAmount => 150;
    public int AmountInGrams { get; private set; }
    public bool IsWarmedUp { get; private set; }
    public Pot? Pot { get; set; }
    public TomatoSauce(Pot pot)
    {
        Pot = pot;
    }
    public static Task<TomatoSauce> CookAsync(Pot pot, int amount)
    {
        if (pot is null)
            throw new ArgumentNullException(nameof(pot));

        if (pot.InUse)
            throw new ArgumentException("The pot ist in use", nameof(pot));

        if (pot.IsHeated == false)
            throw new ArgumentException("The pot is not heated", nameof(pot));

        if (amount > MaxAmount)
            throw new ArgumentOutOfRangeException(nameof(amount), "max. 150g");

        return Task.Run(() =>
        {
            Console.WriteLine($"Cook {amount} g sauce...");
            pot.InUse = true;
            Task.Delay(15_000).Wait();
            pot.InUse = false;
            Console.WriteLine("Sauce is ready");
            return new TomatoSauce(pot)
            {
                IsWarmedUp = true,
                AmountInGrams = amount
            };
        });
    }
}
