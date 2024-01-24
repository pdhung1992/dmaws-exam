using System.ComponentModel.DataAnnotations;

namespace order_api.Models;

public class EditOrderModel
{
    [Required(ErrorMessage = "Order delivery is required")]
    public string OrderDelivery { get; set; }
    
    [Required(ErrorMessage = "Order Address is required")]
    public string OrderAddress { get; set; }
}