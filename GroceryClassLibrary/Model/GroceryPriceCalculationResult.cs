using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryClassLibrary.Model
{
    public class GroceryPriceCalculationResult
    {
        public List<GrocerySaleCalculation> GrocerySaleCalculations = new List<GrocerySaleCalculation>();
      
        public decimal? GrocerySalePrice { get; set; }

       
    }
}
