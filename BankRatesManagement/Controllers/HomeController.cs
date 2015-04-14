using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankRatesManagement.Domain.Concrete;
using BankRatesManagement.Domain.Entities;

namespace BankRatesManagement.Controllers
{
    public class HomeController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRates()
        {
            List<Rate> ratesList = unitOfWork.RateRepository.Get().ToList();
            return Json(ratesList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string UpdateRates(Rate rate) {

            if (rate != null)
            {
                var rateRecord = unitOfWork.RateRepository.GetByID(rate.RateID);
                if (rateRecord != null)
                {
                    rateRecord.Name = rate.Name;
                    rateRecord.Value = rate.Value;
                    unitOfWork.RateRepository.Update(rateRecord);
                    unitOfWork.Save();

                    return "Record has been Updated";
                }
                else
                    return "Update error";
            }
            else
            {
                return "Record has Not been Updated";
            }
        }

        public string Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    unitOfWork.RateRepository.Delete(id);
                    unitOfWork.Save();

                    return "Rate has Been Deleted";
                }
                else
                {
                    return "Rate has not Been Deleted";
                }
            }
            catch
            {
                return "Rate has not Been Deleted";
            }
        }

        public string Add(Rate rate)
        {
            try
            {
                if (rate != null)
                {
                    unitOfWork.RateRepository.Insert(rate);
                    unitOfWork.Save();
                    return "Record has been Added";
                }
                else
                {
                    return "Record has Not been Verified";
                }
            }

            catch
            {
                return "Record has Not been Added";
            }
        }
	}
}