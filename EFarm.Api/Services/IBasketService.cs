using EFarm.Api.Model;

namespace EFarm.Api.Services
{
	public interface IBasketService
	{
        Task AddItem(int id, decimal price, int quantity = 1);
        Task<int> CountTotalBasketItems();
        Task<Basket> GetOrCreateBasketForUser();
	}
}