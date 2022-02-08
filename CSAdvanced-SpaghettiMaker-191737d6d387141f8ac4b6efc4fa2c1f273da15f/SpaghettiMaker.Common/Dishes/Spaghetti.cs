namespace SpaghettiMaker.Common.Dishes;

public class Spaghetti : DishObject
{
    public static int MaxAmount => 200;
    public bool IsCooked { get; private set; }
    public int AmountInGrams { get; private set; }
    public Pot? Pot { get; set; }
    public Spaghetti(Pot pot)
    {
        Pot = pot;
    }
    public static Task<Spaghetti> CookAsync(Pot pot, int amount)
    {
        if (pot is null)
            throw new ArgumentNullException(nameof(pot));

        if (pot.InUse)
            throw new ArgumentException("The pot ist in use", nameof(pot));

        if (pot.IsHeated == false)
            throw new ArgumentException("The pot is not heated", nameof(pot));

        if (amount > MaxAmount)
            throw new ArgumentOutOfRangeException(nameof(amount));

        return Task.Run(() =>
        {
            Console.WriteLine($"Cook {amount} g spaghetti...");
            pot.InUse = true;
            Task.Delay(20_000).Wait();
            pot.InUse = false;
            Console.WriteLine("Spaghetti are ready");
            return new Spaghetti(pot)
            {
                IsCooked = true,
                AmountInGrams = amount,
            };
        });
    }
}

