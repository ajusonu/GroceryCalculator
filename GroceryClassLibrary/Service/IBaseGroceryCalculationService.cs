
using GroceryClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLibrary.Services
{
    public interface IBaseGroceryCalculationService
    {
        /// <summary>
        /// Calculate Total
        /// </summary>
        decimal? CalculateTotal();
        /// <summary>
        /// SetGrocerySaleCalculations
        /// </summary>
        void SetGrocerySaleCalculations();
        /// <summary>
        /// Set Pricing
        /// </summary>
        /// <param name="jsonPricingObject"></param>
        /// <returns></returns>
        void SetPricing(string jsonPricingObject);
        /// <summary>
        /// Scan Product
        /// </summary>
        /// <param name="productCode"></param>
        void ScanProduct(string productCode);
    }
}
