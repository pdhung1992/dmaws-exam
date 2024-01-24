using System.ComponentModel.DataAnnotations;

namespace order_api.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    
    public int ItemCode { get; set; }
    
    public string ItemName { get; set; }
    
    public int ItemQty { get; set; }
    
    public DateTime OrderDelivery { get; set; }
    
    public string OrderAddress { get; set; }
    
    public string PhoneNumber { get; set; }
}