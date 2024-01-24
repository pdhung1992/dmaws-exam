namespace order_api.Models;

public class CreateOrderModel
{
    public int ItemCode { get; set; }
    
    public string ItemName { get; set; }
    
    public int ItemQty { get; set; }
    
    public string OrderDelivery { get; set; }
    
    public string OrderAddress { get; set; }
    
    public string PhoneNumber { get; set; }
}