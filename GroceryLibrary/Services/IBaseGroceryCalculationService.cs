using GroceryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLibrary.Services
{
    public interface IBaseGroceryCalculationService
    {
        Task<GroceryCalculationResult> CalculateTotal(List<Grocery> groceries);
        Task<List<Grocery>> SetPricing(string jsonPricingObject);
        void ScanProduct(string productName);
    }
}
