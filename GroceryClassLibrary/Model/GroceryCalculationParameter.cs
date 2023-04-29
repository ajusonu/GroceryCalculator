using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryClassLibrary.Model
{
    public class GroceryCalculationParameter
    {
        public List<GroceryPricing> GroceryPricings = new List<GroceryPricing>();
        public string GroceryItemList { get; set; }

    }
}
