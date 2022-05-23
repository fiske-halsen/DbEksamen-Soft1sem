using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Services;

namespace MongoAPI.Controllers
{
    public class OrderController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService) =>
            _orderService = orderService;

        [HttpGet]
        public async Task<List<Order>> Get() =>
            await _orderService.GetOrder();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            await _orderService.CreateOrder(order);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }
    }
}
