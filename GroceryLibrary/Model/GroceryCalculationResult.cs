using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLibrary.Model
{
    public class GroceryCalculationResult
    {
        public List<Grocery> Groceries { get; set; }
        public GroceryCalculationResult(List<Grocery> groceries)
        {
            Groceries = groceries;
        }
    }
}
