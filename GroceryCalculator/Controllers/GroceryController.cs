using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroceryClassLibrary.Model;
using GroceryClassLibrary.Service;
using System.Threading.Tasks;


namespace GroceryCalculator.Controllers
{
    public class GroceryController : ApiController
    {

        [HttpPost]
        [Route("api/grocery")]
        public HttpResponseMessage GetGroceryPriceCalculationResult(GroceryCalculationParameter calculationParameter)
        {
            HttpResponseMessage response;
            try
            {
                GroceryCalculationService groceryCalculationService = new GroceryCalculationService();
                GroceryPriceCalculationResult groceryPriceCalculationResult = groceryCalculationService.GetGroceryPriceCalculationResult(calculationParameter);

                // prepare Success response
                response = Request.CreateResponse<GroceryPriceCalculationResult>(HttpStatusCode.OK, groceryPriceCalculationResult);

            }
            catch (Exception ex)
            {
                //log error
                string errorContent = $"Error details {ex.Message}";
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(errorContent)
                };
            }



            return response;

        }
        /// <summary>
        /// Default test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/grocery")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
    }
}
