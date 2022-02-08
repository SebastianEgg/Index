namespace SpaghettiMaker.Common.Dishes;

public class Pot 
{
    public bool InUse { get; set; }
    public bool IsHeated { get; private set; } = false;
    public static Task<Pot> HeatAsync()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Heating Pot...");
            Task.Delay(10_000).Wait();
            Console.WriteLine("Pot is ready");
            return new Pot()
            {
                IsHeated = true
            };
        });
    }
}