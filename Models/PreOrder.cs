namespace DD_FootwearAPI.Models
{
    public class PreOrder
    {
        public int PreOrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string OrderStatus { get; set; }
        public bool LockStatus { get; set; }
    }
}
