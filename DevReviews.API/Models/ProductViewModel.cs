using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class ProductViewModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public ProductViewModel(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}
