using DevReviews.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext
    {
        public List<Product> Products { get; set; }
        public DevReviewsDbContext()
        {
            Products = new List<Product>();
        }
    }
}
