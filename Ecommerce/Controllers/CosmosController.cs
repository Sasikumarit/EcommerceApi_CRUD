using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PwC_Ecommerce.DataAccess;
using PwC_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PwC_Ecommerce.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        /// <summary>
        /// </summary>
        ICosmosDataAdapter _adapter;
        public CosmosController(ICosmosDataAdapter adapter)
        {
            _adapter = adapter;
        }

        //// GET: api/Cosmos/5
        //[HttpGet("createdb")]
        //public async Task<IActionResult> CreateDatabase()
        //{
        //    var result = await _adapter.CreateDatabase("Ecommerce");
        //    return Ok(result);
        //}

        //[HttpGet("createcollection")]
        //public async Task<IActionResult> CreateCollection()
        //{
        //    var result = await _adapter.CreateCollection("Ecommerce", "Order");
        //    return Ok(result);
        //}

        //[HttpPost("createdocument")]
        //public async Task<IActionResult> CreateDocument([FromBody] UserInfo user)
        //{
        //    var result = await _adapter.CreateDocument("Ecommerce", "Order", user);
        //    return Ok(result);
        //}

        [HttpPost("placeorder")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            var result = await _adapter.PlaceOrder("Ecommerce", "Order", order);
            return Ok();
        }
        [HttpGet("getOrder")]
        public async Task<IActionResult> Get()
        {
            var result = await _adapter.GetData("Ecommerce", "Order");
            return Ok(result);
        }

        // POST: api/Cosmos
        [HttpPost("updateOrder")]
        public async Task<IActionResult> Post([FromBody] UserInfo user)
        {
            var result = await _adapter.UpsertUserAsync(user);
            return Ok();
        }

        // PUT: api/Cosmos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _adapter.DeleteUserAsync("Ecommerce", "Order", id);
            return Ok(result);
        }
    }
}
