using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PwC_EcommerceApi.Context;
using PwC_EcommerceApi.Model;
using PwC_EcommerceApi.Repository;
using System.Net;

namespace PwC_EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyDBContext _myDBContext;
        private readonly OrderRepository<Order> _orderRepository;

        public OrderController(OrderRepository<Order> orderRepository, MyDBContext myDBContext)
        {
            _orderRepository = orderRepository;
            _myDBContext = myDBContext;
        }


        //[HttpPost("SaveOrders")]
        //public ActionResult SaveOrder()
        //{
        //    var order = new Order()
        //    {
        //        Id = "1",
        //        PartitionKey = "1",
        //        Date = DateTime.Now,
        //        Customer = new Customer()
        //        {
        //            Mobile = "1234567890",
        //            Name = "Sasikumar",
        //            Address = new Address()
        //            {
        //                City = "CBE",
        //                State = "Tamilnadu",
        //                AddressLine1 = "Address",
        //                Pincode = "641017",
        //            }
        //        },
        //        OrderItems = new List<OrderItem>()
        //        {
        //            new OrderItem()
        //            {
        //                Name="Item 1",
        //                MRP="20",
        //                Price ="15",
        //                OrderId="1",
        //            },
        //              new OrderItem()
        //            {
        //                Name="Item 2",
        //                MRP="100",
        //                Price ="90",
        //                OrderId="1",
        //            }
        //        }
        //    };
        //    _myDBContext.Order.Add(order);
        //    var order2 = new Order()
        //    {
        //        Id = "2",
        //        PartitionKey = "2",
        //        Date = DateTime.Now,
        //        Customer = new Customer()
        //        {
        //            Mobile = "1234567890",
        //            Name = "Sasikumar",
        //            Address = new Address()
        //            {
        //                City = "CBE",
        //                State = "Tamilnadu",
        //                AddressLine1 = "Address",
        //                Pincode = "641017",
        //            }
        //        },
        //        OrderItems = new List<OrderItem>()
        //        {
        //            new OrderItem()
        //            {
        //                Name="Item 1",
        //                MRP="50",
        //                Price ="50",
        //                OrderId="2",
        //            },
        //              new OrderItem()
        //            {
        //                Name="Item 2",
        //                MRP="150",
        //                Price ="14",
        //                OrderId="2",
        //            }
        //        }
        //    };
        //    _myDBContext.Order.Add(order);
        //    _myDBContext.SaveChanges();
        //    return Ok();
        //}


        [HttpGet]
        public IActionResult GetAllItems()
        {
            var items = _orderRepository.GetAll().ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var item = await _orderRepository.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Order order)
        {
            await _orderRepository.Add(order);
            return CreatedAtAction(nameof(GetItem), new { id = order.id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, Order item)
        {
            if (id.ToString() != item.id)
                return BadRequest();

            await _orderRepository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            await _orderRepository.Delete(id);
            return NoContent();
        }
    }
}
