using EFarm.Api.Data;
using EFarm.Api.Model;
using EFarm.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFarm.Api.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
      readonly  IRepository<Basket> _repository;
        readonly IBasketService _basketService;
        Basket basket;
        public BasketController(IRepository<Basket> repository, IBasketService basketService)
        {
            _repository = repository;
            _basketService = basketService;
            basket = basketService.GetOrCreateBasketForUser().GetAwaiter().GetResult();
        }

        // GET: api/<BasketController>
        [HttpGet]
        public async    Task< Basket> Get()
        {
            return await _basketService.GetOrCreateBasketForUser();
        }

        [HttpGet("count")]
		public async Task<int> CountBasketItems() =>await _basketService.CountTotalBasketItems();
        
        [HttpPost("add")]
		public async Task AddItem([FromBody]BasketItemDto item) =>
            await _basketService.AddItem(item.ProductId, item.UnitPrice, item.Quantity);
  
    }

    public class BasketItemDto
    {
        public int ProductId { get;   set; }
        public decimal UnitPrice { get;   set; }
        public int Quantity { get;   set; }
    }
}
