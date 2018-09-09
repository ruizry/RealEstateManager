using RealEstateManager;
using RealEstateManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateTracker.Controllers
{
    public class ListingsController : Controller
    {
        // GET: Listings
        public ActionResult Index()
        {
            using (RealEstateEntity db = new RealEstateEntity())
            {
                var listings = db.Listings.ToList();
                if (listings.Count() > 0)
                    return View(listings);
                else
                    return View("NoResults");
            }
        }

        public ActionResult Details(string lookupID)
        {
            return View();
        }
    }
}