﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Product
    {
        public int id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int stock { get; set; }
        public int ViewCount { get; set; }
        public string SeoAlias { get; set; }
    }
}
