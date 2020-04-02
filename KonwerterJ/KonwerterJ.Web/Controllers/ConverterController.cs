using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

using System.Web.Mvc;
using KonwerterJ.Services;

namespace KonwerterJ.Web.Controllers
{
    public class ConvertersController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public ConvertersController(ILifetimeScope scope, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }
        public List<IConverter> GetConverters()
        {

            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }
        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
         string converterType)
        {
            converterType = HttpUtility.UrlDecode(converterType);
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Name == converterType).FirstOrDefault();

            decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

            return output;
        }
    }
}
