using EFarm.Api.Model;

namespace EFarm.Api.Model
{
	public class Basket : BaseEntity
    {
        public string BuyerId { get; set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public List<BasketItem> Items { get; set; }

        public int TotalItems => _items.Sum(i => i.Quantity);


        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }

        public void AddItem(int productId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId))
            {
                _items.Add(new BasketItem(productId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.First(i => i.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }

}
