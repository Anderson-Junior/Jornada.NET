﻿using System;

namespace DevReviews.API.Entities
{
    public class ProductReview
    {
        public int MyProperty { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public string Comments { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public int ProductId { get; private set; }
        public ProductReview(string author, int rating, string comments, int productId)
        {
            Author = author;
            Rating = rating;
            Comments = comments;
            ProductId = productId;
            RegisteredAt = DateTime.Now;
        }
    }
}
