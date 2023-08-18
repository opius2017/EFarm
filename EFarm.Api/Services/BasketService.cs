using EFarm.Api.Data;
using EFarm.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EFarm.Api.Services
{
    public class BasketService : IBasketService
    {
       readonly AppDbContext _dbContext;
        readonly IAppSession _session;
		public BasketService(AppDbContext dbContext, IAppSession session)
		{
			_dbContext = dbContext;
			_session = session;
		}

        public async Task AddItem(int productId, decimal unitPrice, int quantity = 1)
        {
            var basket =await GetOrCreateBasketForUser();

            basket.AddItem(productId, unitPrice, quantity);
            _dbContext.Baskets.Update(basket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CountTotalBasketItems()
        {
            var totalItems = await _dbContext.Baskets
                .Where(basket => basket.BuyerId == _session.UserId)
                .SelectMany(item => item.Items)
                .SumAsync(sum => sum.Quantity);

            return totalItems;
        }

        public async Task<Basket> GetOrCreateBasketForUser()
        {
            var userId=_session.UserId;
             var basket = await GetUserBasket(userId);

            if (basket == null)
            {
                return await CreateBasketForUser(userId);
            }
           return basket;
        }

         

        private async Task<Basket> CreateBasketForUser(string userId)
        {
            var basket = new Basket(userId);
            await _dbContext.Baskets.AddAsync(basket);
            await _dbContext.SaveChangesAsync();

            return basket;
        }


		private async Task<Basket> GetUserBasket(string userId)
		{
			return await _dbContext.Baskets.Include(x=>x.Items).FirstOrDefaultAsync(x => x.BuyerId == userId);
		}
	}
}
