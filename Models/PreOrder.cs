using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DD_FootwearAPI.Models
{
    public class PreOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int PreOrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public bool LockStatus { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CustomerID { get; set; }

        [Required]
        public DateTime PreOrderedDate { get; set; }
    }
}
