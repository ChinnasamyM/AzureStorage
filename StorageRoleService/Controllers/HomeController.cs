using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureStorageLib;

namespace StorageRoleService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            TableStorage objTableStorage = new TableStorage();
           // objTableStorage.AzureTableQuery();
            objTableStorage.AzureTableRetriveQuery();
            return View();
            
        }
    }
}
