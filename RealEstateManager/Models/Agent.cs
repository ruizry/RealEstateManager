using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RealEstateManager.Models
{
    public class Agent
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string ContactNum { get; set; }
        public string Website { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
    }
}