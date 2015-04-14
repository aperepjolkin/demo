using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankRatesManagement.Domain.Entities;
using System.Data.Entity.Validation;
namespace BankRatesManagement.Domain.Concrete
{
    public class EFDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var rateList = new List<Rate>
            {
                new Rate { Name = "Opening an account", Value = "10 EUR" },
                new Rate { Name = "Account maintenance", Value = "5 EUR per year" },
                new Rate { Name = "Maintenance of an inactive account", Value = "10 EUR per year" },
                new Rate { Name = "Closing an account", Value = "Free of charge" }
            };

            rateList.ForEach(s => context.Rates.Add(s));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                foreach (var eve in e.EntityValidationErrors)
                {

                    string name = eve.Entry.Entity.GetType().Name;
                    string name2 = eve.Entry.State.ToString();
                    foreach (var ve in eve.ValidationErrors)
                    {

                        string pn = ve.PropertyName;
                        string errM = ve.ErrorMessage;
                    }
                }
            }
        }
    }
}
