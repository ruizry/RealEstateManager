using RealEstateManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealEstateManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProperty(string firstName, string lastName, string contactNum, string address, string city, string state, string firstNameA, string lastNameA, string contactNumA, string listingPrice)
        {
            bool PriceCheck = decimal.TryParse(listingPrice, out decimal listingValue);
            if (PriceCheck)
            {
                using (RealEstateEntity db = new RealEstateEntity())
                {
                    var newProperty = new Property();
                    newProperty.OwnerFirstName = firstName;
                    newProperty.OwnerLastName = lastName;
                    newProperty.ContactNum = contactNum;
                    newProperty.Address = address;
                    newProperty.City = city;
                    newProperty.State = state;

                    db.Properties.Add(newProperty);
                    db.SaveChanges();

                    var newAgent = new Agent();
                    newAgent.FirstName = firstNameA;
                    newAgent.LastName = lastNameA;
                    newAgent.ContactNum = contactNumA;

                    db.Agents.Add(newAgent);
                    db.SaveChanges();

                    var newListing = new Listing();
                    newListing.ListingPrice = listingValue;
                    newListing.ListingStart = DateTime.Now;
                    newListing.PropertyID = newProperty.ID;
                    newListing.AgentID = newAgent.ID;

                    db.Listings.Add(newListing);
                    db.SaveChanges();

                }
                return View("Success");
            }
            else
            {
                return View("PriceError");
            }


        }

        [HttpGet]
        public ActionResult LookupProperty(string lookupAddress)
        {
            if (string.IsNullOrEmpty(lookupAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (RealEstateEntity db = new RealEstateEntity())
                {
                    var results = db.Properties.Where(a => a.Address.Contains(lookupAddress)).FirstOrDefault();
                    //var results = db.Properties.Where(a => Regex.IsMatch(a.Address, lookupAddress, RegexOptions.IgnoreCase)).FirstOrDefault();
                    return View(results);
                }
            }
        }

    }
}