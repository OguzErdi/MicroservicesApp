namespace Basket.API.Entities
{
    public class BasketCartItem
    {
        public int Quantitiy { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        //denormalized table, for higher perfromance
        public string ProductName { get; set; }

    }
}