using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BankRatesManagement.Domain.Entities
{
    public class Rate
    {
        public int RateID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Test5 { get; set; }
    }
}
