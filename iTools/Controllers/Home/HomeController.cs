using iTools.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTools.Controllers.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BMI()
        {
            BMIViewModel viewModel = new BMIViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult BMI(BMIViewModel viewModel)
        {
            decimal iHeight = 0;
            decimal iWeight = 0;
            decimal iBMI = 0;

            decimal.TryParse(viewModel.Height, out iHeight);
            decimal.TryParse(viewModel.Weight, out iWeight);

            iBMI = iWeight / ((iHeight / 100) * (iHeight / 100));

            viewModel.BMI = Math.Round(iBMI, 2, MidpointRounding.AwayFromZero).ToString();
            
            return View(viewModel);
        }
    }
}