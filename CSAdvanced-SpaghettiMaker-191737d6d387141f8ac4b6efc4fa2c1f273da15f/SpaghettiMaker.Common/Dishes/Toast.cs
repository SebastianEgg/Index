namespace SpaghettiMaker.Common.Dishes;

public class Toast : DishObject
{
    public bool IsToasted { get; private set; }

    public static Task<Toast> ToastBreadAsync()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Toasting bread...");
            Task.Delay(10_000).Wait();
            Console.WriteLine("Bread is ready");
            return new Toast()
            {
                IsToasted = true,
            };
        });
    }
}

