namespace GroceryLibrary.Model
{
    public class Grocery
    {
        /// <summary>
        /// Grocery item Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Item Name
        /// </summary>
        public string Name { get; set; }
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