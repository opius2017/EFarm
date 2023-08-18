using EFarm.Client.Model;

namespace EFarm.Client.Model
{
	public class BasketItem 
{
        public int? Id { get; set; }
        public decimal UnitPrice { get;  set; }
    public int Quantity { get;   set; }
    public int ProductId { get;   set; }
    public int? BasketId { get;   set; }
    public Product? Product { get;   set; }


     
}

}
