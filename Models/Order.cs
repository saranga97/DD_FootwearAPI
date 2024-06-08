using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DD_FootwearAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Product ID is required")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Order status is required")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "User is required")]
        [ForeignKey("User")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; }

        // Other properties as needed
    }
}
