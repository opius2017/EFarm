using EFarm.Client.Model;

namespace EFarm.Client.Model
{
	public class Basket 
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public IReadOnlyCollection<BasketItem> Items { get; set; }

        public int TotalItems => Items.Sum(i => i.Quantity);
        public decimal TotalAmount => Items.Sum(i => i.UnitPrice);



	}

}
