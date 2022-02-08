using SpaghettiMaker.Common.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaghettiMaker.Logic
{
    public class SpaghettiMakerv2
    {

        public static async Task<IEnumerable<DishObject>> MakeAsyncNew()
        {
            var result = new List<DishObject>();
            var potTask = new List<Task<Pot>>();
            var pourWaterTask = new List<Task>();
            var pourWineTask = new List<Task>();
            var cookTomatoSauce = new List<Task>();
            var cookSpaghetti = new List<Task>();
            var breadToast = new List<Task>();

            pourWaterTask.Add(Water.PourAsync());
            pourWineTask.Add(Water.PourAsync());

            breadToast.Add(Toast.ToastBreadAsync());
            breadToast.Add(Toast.ToastBreadAsync());

            potTask.Add(Pot.HeatAsync());
            potTask.Add(Pot.HeatAsync());
            potTask.Add(Pot.HeatAsync());

            await Task.WhenAll(potTask.ToArray());

            var pot = potTask.Select(p => p.Result).ToArray();

            cookSpaghetti.Add(Spaghetti.CookAsync(pot[0],200));
            cookSpaghetti.Add(Spaghetti.CookAsync(pot[1], 150));
            cookTomatoSauce.Add(Spaghetti.CookAsync(pot[2], 150));
            
            Task.WaitAny(cookTomatoSauce.ToArray());

            cookTomatoSauce.Add(Spaghetti.CookAsync(pot.First(pt=>pt.InUse == false), 50));

            await Task.WhenAll(pourWaterTask.ToArray());

            foreach (var item in pourWaterTask)
            {
                if(item is Task<Water> wt)
                {
                    result.Add(wt.Result);
                }
            }

            await Task.WhenAll(pourWineTask.ToArray());

            foreach (var item in pourWineTask)
            {
                if (item is Task<Redwine> rw)
                {
                    result.Add(rw.Result);
                }
            }

            await Task.WhenAll(breadToast.ToArray());

            foreach (var item in breadToast)
            {
                if (item is Task<Toast> toa)
                {
                    result.Add(toa.Result);
                }
            }

            await Task.WhenAll(cookSpaghetti.ToArray());

            foreach (var item in cookSpaghetti)
            {
                if (item is Task<Spaghetti> spa)
                {
                    result.Add(spa.Result);
                }
            }

            await Task.WhenAll(cookTomatoSauce.ToArray());

            foreach (var item in cookSpaghetti)
            {
                if (item is Task<TomatoSauce> tos)
                {
                    result.Add(tos.Result);
                }
            }


            return result;
        }

    }
}
