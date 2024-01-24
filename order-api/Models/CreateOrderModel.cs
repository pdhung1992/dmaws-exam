using System.ComponentModel.DataAnnotations;

namespace order_api.Models;

public class CreateOrderModel
{
    [Required(ErrorMessage = "Item code is required")]
    public int ItemCode { get; set; }
    
    [Required(ErrorMessage = "Item name is required")]
    public string ItemName { get; set; }
    
    [Required(ErrorMessage = "Item quantity is required")]
    public int ItemQty { get; set; }
    
    [Required(ErrorMessage = "Order delivery is required")]
    public string OrderDelivery { get; set; }
    
    [Required(ErrorMessage = "Order Address is required")]
    public string OrderAddress { get; set; }
    
    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; }
}