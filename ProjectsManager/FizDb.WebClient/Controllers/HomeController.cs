using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizDb.WebClient.Models;

namespace FizDb.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string table)
        {
            ViewBag.Message = "Дані системи";
            var model = new DatabaseModel();
            //model.DataSet = Container.Dataset;
            model.Tables = Container.Dataset.tables.Select(kv => kv.Key).ToList();
            var tbl = string.IsNullOrEmpty(table)
                          ? Container.Dataset.tables.First().Value
                          : Container.Dataset.tables[table];
            model.CurrentTable = TableViewModel.Create(tbl);
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
