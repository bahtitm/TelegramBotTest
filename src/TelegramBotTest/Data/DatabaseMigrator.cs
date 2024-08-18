using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TelegramBotTest.Data
{
    public class DatabaseMigrator
    {
        private readonly AppDbContext appDbContext;

        public DatabaseMigrator(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task MigrateAsync()
        {
            await appDbContext.Database.MigrateAsync();
            var anyPaymentnpriod = appDbContext.Set<PaymentPeriod>().Any();

            if (anyPaymentnpriod == false)
            {
                var paymentnpriods = new List<PaymentPeriod>()
               {
                new PaymentPeriod { Id=1, Payment=6, Period =Period.Week, },
                new PaymentPeriod { Id=2, Payment = 8, Period = Period.TwoWeek, },
                new PaymentPeriod { Id=3, Payment = 9, Period = Period.ThreeMonth, },
                new PaymentPeriod { Id=4,Payment = 10, Period = Period.SixMonth, },
                new PaymentPeriod { Id=5,Payment = 11, Period = Period.Month, },
                    };

                await appDbContext.Set<PaymentPeriod>().AddRangeAsync(paymentnpriods);
               

               

            }
            var anySubscription = appDbContext.Set<Subscription>().Any();

            if (anySubscription == false)
            {
                var subscriptions = new List<Subscription>()
               {
                new Subscription { Id=1, PaymentPeriodId=1, Name="Subscribtion1", Description="This Subscribtion 1"    },
                new Subscription { Id=2, PaymentPeriodId=2, Name="Subscribtion2", Description="This Subscribtion 2"  },
                new Subscription { Id=3,  PaymentPeriodId = 3, Name="Subscribtion3", Description="This Subscribtion 3"  },
               
                    };

                await appDbContext.Set<Subscription>().AddRangeAsync(subscriptions);
               



            }
            await appDbContext.SaveChangesAsync();
          
        }
    }
}
