using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryClassLibrary.Model
{
    public class GroceryPricing
    {
      
        /// <summary>
        /// Item Name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Units is no of Unit for Pricing
        /// </summary>
        public int Unit { get; set; }
        /// <summary>
        /// Price  is unit price if Units =1 
        /// </summary>
        public decimal Price { get; set; }


    }
}
