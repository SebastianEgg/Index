using SpaghettiMaker.Common.Dishes;

namespace SpaghettiMaker.Logic;
public class DinnerMakerAsync
{
    public static async Task<IEnumerable<DishObject>> MakeAsync()
    {
        var result = new List<DishObject>();
        var potTasks = new List<Task<Pot>>();
        var spaghettiOrSauceTasks = new List<Task>();
        var sauceTasks = new List<Task>();
        var pourTasks = new List<Task>();
        var toastTasks = new List<Task>()
            {
                Toast.ToastBreadAsync(),
                Toast.ToastBreadAsync(),
            };

        pourTasks.Add(Redwine.PourAsync());
        pourTasks.Add(Water.PourAsync());
                

        // Toepfe aufwaermen
        potTasks.Add(Pot.HeatAsync());
        potTasks.Add(Pot.HeatAsync());
        potTasks.Add(Pot.HeatAsync());
        await Task.WhenAll(potTasks.ToArray());
        
        var pots = potTasks.Select(pt => pt.Result).ToArray();

        spaghettiOrSauceTasks.Add(Spaghetti.CookAsync(pots[0], 200));
        spaghettiOrSauceTasks.Add(Spaghetti.CookAsync(pots[1], 150));
        spaghettiOrSauceTasks.Add(TomatoSauce.CookAsync(pots[2], 150));

        Task.WaitAny(spaghettiOrSauceTasks.ToArray());

        spaghettiOrSauceTasks.Add(TomatoSauce.CookAsync(pots.First(p => p.InUse == false), 50));
        await Task.WhenAll(pourTasks.ToArray());
        foreach (var task in pourTasks)
        {
            if (task is Task<Redwine> rt)
                result.Add(rt.Result);
            else if (task is Task<Water> wt)
                result.Add(wt.Result);
        }
        await Task.WhenAll(toastTasks.ToArray());
        foreach (var task in toastTasks)
        {
            if (task is Task<Toast> rt)
                result.Add(rt.Result);
        }
        await Task.WhenAll(spaghettiOrSauceTasks.ToArray());
        foreach (var task in spaghettiOrSauceTasks)
        {
            if (task is Task<Spaghetti> st)
                result.Add(st.Result);
            else if (task is Task<TomatoSauce> tt)
                result.Add(tt.Result);
        }
        return result;
    }
}