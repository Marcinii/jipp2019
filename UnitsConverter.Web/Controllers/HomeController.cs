﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitsConverter;
using UnitsConverter.Model;
using UnitsConverter.Services;

namespace UnitsConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConverterService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string value,
            string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;

            decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(value));

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