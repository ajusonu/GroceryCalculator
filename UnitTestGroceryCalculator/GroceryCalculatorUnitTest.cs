using GroceryClassLibrary;
using GroceryClassLibrary.Model;
using GroceryClassLibrary.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestGroceryCalculator
{
    [TestClass]
    public class GroceryCalculatorUnitTest
    {
        readonly string JsonGroceryPricingFileName = "GroceryPricingList.json";

        [TestMethod]
        public void GroceryCalculationServiceTest()
        {

            string jsonPricingObject = ReturnJSON_string(JsonGroceryPricingFileName);

            GroceryCalculationService groceryCalculationService = new GroceryCalculationService();
            groceryCalculationService.ScanProduct("A");
            groceryCalculationService.ScanProduct("B");
            groceryCalculationService.SetPricing(jsonPricingObject);
            groceryCalculationService.SetGrocerySaleCalculations();
            decimal? totalCalculation = groceryCalculationService.CalculateTotal();

            Assert.IsNotNull(totalCalculation);



        }
        [TestMethod]
        public void GroceryCalculationServiceTest1()
        {

            string jsonPricingObject = ReturnJSON_string("GroceryPricingList.json");
            GroceryCalculationService groceryCalculationService = new GroceryCalculationService();
            groceryCalculationService.SetPricing(jsonPricingObject);

            string itemList = "ABCDABA";
            foreach (char productName in itemList.ToCharArray())
            {
                groceryCalculationService.ScanProduct(productName.ToString());

            }
            groceryCalculationService.SetGrocerySaleCalculations();
            decimal? totalCalculation = groceryCalculationService.CalculateTotal();

            Assert.AreEqual((decimal)totalCalculation, (decimal)13.25);



        }
        [TestMethod]
        public void GroceryCalculationServiceTest2()
        {

            string jsonPricingObject = ReturnJSON_string("GroceryPricingList.json");
            GroceryCalculationService groceryCalculationService = new GroceryCalculationService();
            groceryCalculationService.SetPricing(jsonPricingObject);

            string itemList = "CCCCCCC";
            foreach (char productName in itemList.ToCharArray())
            {
                groceryCalculationService.ScanProduct(productName.ToString());

            }
            groceryCalculationService.SetGrocerySaleCalculations();
            decimal? totalCalculation = groceryCalculationService.CalculateTotal();

            Assert.AreEqual(totalCalculation, 6);



        }
        [TestMethod]
        public void GroceryCalculationServiceTest3()
        {

            string jsonPricingObject = ReturnJSON_string("GroceryPricingList.json");

            GroceryCalculationService groceryCalculationService = new GroceryCalculationService();
            groceryCalculationService.ScanProduct("A");
            groceryCalculationService.ScanProduct("B");
            groceryCalculationService.ScanProduct("C");
            groceryCalculationService.ScanProduct("D");
            groceryCalculationService.SetPricing(jsonPricingObject);
            groceryCalculationService.SetGrocerySaleCalculations();
            decimal? totalCalculation = groceryCalculationService.CalculateTotal();

            Assert.AreEqual((decimal)totalCalculation, (decimal)7.25);



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReturnJSON_string(string fileName)
        {
            string result;

            string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string incomingGroceryPricing = string.Empty;

            using (StreamReader r = new StreamReader(string.Format(fileName, exePath)))
            {
                result = r.ReadToEnd();
            }



            return result;

        }
        [TestMethod]
        public void TestLogic()
        {

            string itemList = "ABCDABA";
            //GroceryProductCountTotals   
            List<Grocery> groceries = new List<Grocery>();
            //var unique_items = new HashSet<char>(itemList.ToCharArray());
            //foreach (char item in unique_items)
            //{
            foreach (char productName in itemList.ToCharArray())
            {
                groceries.Add(new Grocery() { ProductName = productName.ToString() });
            }
            //}

            var results = groceries
            .GroupBy(p => p.ProductName)
            .Select(group => new { ProductName = group.Key, ProductCount = group.Count() }).OrderBy(p => p.ProductName);

            List<GroceryPricing> groceryPricings = GetGroceryPricings();

            List<GrocerySaleCalculation> grocerySaleCalculations = new List<GrocerySaleCalculation>();
            foreach (var product in results)
            {
                GrocerySaleCalculation grocerySaleCalculation = new GrocerySaleCalculation(groceryPricings, product.ProductName, product.ProductCount);
                grocerySaleCalculation.CalculateProductTotal();
                grocerySaleCalculations.Add(grocerySaleCalculation);

            }
            Assert.IsNotNull(results);

        }
        public List<GroceryPricing> GetGroceryPricings()
        {
            string payLoadResult = ReturnJSON_string(JsonGroceryPricingFileName);
            List<GroceryPricing> groceries = JsonConvert.DeserializeObject<List<GroceryPricing>>(payLoadResult);
            return groceries;
        }
        [TestMethod]
        public void TestMethod1()
        {
            //var groceryCalculator = new GroceryCalculator();
            string payLoadResult = ReturnJSON_string(JsonGroceryPricingFileName);
            List<GroceryPricing> groceries = JsonConvert.DeserializeObject<List<GroceryPricing>>(payLoadResult);
            Assert.IsNotNull(payLoadResult);
        }

    }

}
