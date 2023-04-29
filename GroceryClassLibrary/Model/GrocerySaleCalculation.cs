using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryClassLibrary.Model
{
    public class GrocerySaleCalculation
    {
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public decimal? ProductTotalPrice { 
            get { 
                return CalculateProductTotal(); 
            } 
        }

        public int? BulkUnit { get { return GetUnitsForBulkPriceIfExists(); } }

        public decimal? BulkUnitPrice { get { return GetProductBulkPrice(); } }

        public decimal? UnitPrice { get { return GetProductUnitPrice(); } }

        List<GroceryPricing> _GroceryPricings = new List<GroceryPricing>();
        public GrocerySaleCalculation(List<GroceryPricing> groceryPricings, string productName, int productCount)
        {
            _GroceryPricings = groceryPricings;
            ProductName = productName;
            ProductCount = productCount;
        }
       
        public decimal? CalculateProductTotal()
        {
            
            //decimal total = 0;
            if(ProductCount == 1 || BulkUnit == null)
            {

                return UnitPrice * ProductCount;

            }
            else
            {
                if(BulkUnit != null && BulkUnitPrice != null)
                {
                    int numBulkItems = ProductCount / (int)BulkUnit;
                    int unitItems = ProductCount % (int)BulkUnit;

                    return numBulkItems * (decimal)BulkUnitPrice + unitItems * UnitPrice;
                }

            }
            
            return null;
        }
        /// <summary>
        /// Assuming that Unit price will always exists
        /// </summary>
        /// <returns></returns>
        private decimal? GetProductUnitPrice()
        {
            GroceryPricing groceryUnitPricing = _GroceryPricings.Find(x => x.ProductName == ProductName && x.Unit == 1);
            if (groceryUnitPricing == null)
            {
                return null;
            }
            else
            {
                return groceryUnitPricing.Price;
            }
        }
        private decimal? GetProductBulkPrice()
        {
            GroceryPricing groceryPricing = _GroceryPricings.Find(x => x.ProductName == ProductName && x.Unit > 1);
            if(groceryPricing == null)
            {
                return null;
            }
            else
            {
                return groceryPricing.Price;
            }
        }
        private int? GetUnitsForBulkPriceIfExists()
        {
            GroceryPricing groceryPricing= _GroceryPricings.Find(x => x.ProductName == ProductName && x.Unit > 1);
            if (groceryPricing == null)
            {
                return null;
            }
            else
            {
                return groceryPricing.Unit;
            }
        }

    }
}
