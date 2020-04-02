using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zal.Logika.Serwisy;

namespace zal.strona.Controllers
{
    public class HomeController : Controller
    {
        private SerwisConwerterow serwisConwerterow;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, SerwisConwerterow serwisConwerterow)
        {
            this.serwisConwerterow = serwisConwerterow;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<IConverter> converters = this.serwisConwerterow.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;

            decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

            return output;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}