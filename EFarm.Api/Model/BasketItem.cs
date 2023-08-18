using EFarm.Api.Model;

namespace EFarm.Api.Model
{
	public class BasketItem : BaseEntity
{

    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public int BasketId { get; private set; }
    public Product? Product { get; private set; }
        public BasketItem()
        {
            
        }

        public BasketItem(int productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        SetQuantity(quantity);
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }
}

}
