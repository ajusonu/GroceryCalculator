using GroceryClassLibrary.Model;
using GroceryLibrary.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryClassLibrary.Service
{
    public class GroceryCalculationService : IBaseGroceryCalculationService
    {
        private List<GroceryPricing> GroceryPricings = new List<GroceryPricing>();
        public string GroceryItemList { get; set; } = string.Empty;

        GroceryPriceCalculationResult _GroceryPriceCalculationResult = new GroceryPriceCalculationResult();
        public decimal? CalculateTotal()
        {
           decimal? totalPrice = (from itemCalculation in _GroceryPriceCalculationResult.GrocerySaleCalculations select itemCalculation.ProductTotalPrice).Sum();
            _GroceryPriceCalculationResult.GrocerySalePrice = totalPrice;
            return totalPrice;
        }

        /// <summary>
        /// Set Grocery Sale Calculations
        /// </summary>
        public void SetGrocerySaleCalculations()
        {
            List<Grocery> groceries = new List<Grocery>();
            foreach (char productName in GroceryItemList.ToCharArray())
            {
                groceries.Add(new Grocery() { ProductName = productName.ToString() });
            }
            //}

            var results = groceries
            .GroupBy(p => p.ProductName)
            .Select(group => new { ProductName = group.Key, ProductCount = group.Count() }).OrderBy(p => p.ProductName);

            //List<GroceryPricing> groceryPricings = GetGroceryPricings();

            List<GrocerySaleCalculation> grocerySaleCalculations = new List<GrocerySaleCalculation>();
            foreach (var product in results)
            {
                GrocerySaleCalculation grocerySaleCalculation = new GrocerySaleCalculation(GroceryPricings, product.ProductName, product.ProductCount);
                grocerySaleCalculation.CalculateProductTotal();
                grocerySaleCalculations.Add(grocerySaleCalculation);

            }
            _GroceryPriceCalculationResult.GrocerySaleCalculations = grocerySaleCalculations;
        }
        /// <summary>
        /// Scan Product
        /// </summary>
        /// <param name="productCode"></param>

        public void ScanProduct(string productCode)
        {
            GroceryItemList = $"{GroceryItemList}{productCode}";
        }

        public void SetPricing(string jsonPricingObject)
        {
            try
            {
                List<GroceryPricing> groceryPricings = JsonConvert.DeserializeObject<List<GroceryPricing>>(jsonPricingObject);
                GroceryPricings = groceryPricings;
            }
            catch (Exception ex)
            {
                GroceryPricings = null;
            }


        }
        /// <summary>
        /// Get Grocery Price Calculation Result
        /// </summary>
        /// <param name="jsonPricingObject"></param>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public GroceryPriceCalculationResult GetGroceryPriceCalculationResult(GroceryCalculationParameter calculationParameter)
        {

            GroceryPricings = calculationParameter.GroceryPricings;
            foreach (char productName in calculationParameter.GroceryItemList.ToCharArray())
            {
                ScanProduct(productName.ToString());

            }
            SetGrocerySaleCalculations();
            CalculateTotal();

            return _GroceryPriceCalculationResult;



        }
    }
}
