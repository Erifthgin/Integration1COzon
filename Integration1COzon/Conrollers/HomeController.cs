using Integration1COzon.Application.Abstractions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace Integration1COzon.Conrollers
{
    public class HomeController : Controller
    {
        IIntegrationHandler Handle;
        public HomeController(IIntegrationHandler handle)
        {
            Handle = handle;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var service = Handle.Handle(Application.Domanes.Enum.StorageType.CTC);

            return View(service);
        }

        // GET: HomeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: HomeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
