namespace DD_FootwearAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string OrderStatus { get; set; }
    }
}
