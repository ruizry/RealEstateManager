using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateManager.Models
{
    public class Listing
    {
        public int ListingID { get; set; }
        public int PropertyID { get; set; }
        public int AgentID { get; set; }
        [DisplayName("Listing Price"), DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ListingPrice { get; set; }
        [DisplayName("Selling Price"), DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? SellingPrice { get; set; }
        [DisplayName("Starting List Date")]
        public DateTime ListingStart { get; set; }
        public DateTime? ListingEnd { get; set; }

        public virtual Property Property { get; set; }
        public virtual Agent Agent { get; set; }
    }
}