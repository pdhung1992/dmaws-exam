using System.Globalization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using order_api.Contexts;
using order_api.DTOs;
using order_api.Entities;
using order_api.Models;

namespace order_api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly DBContext dbContext;
        
        public OrderController(DBContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<OrderDTO> orders = dbContext.Orders
                .Select(order => new OrderDTO()
                {
                    ItemCode = order.ItemCode,
                    ItemName = order.ItemName,
                    ItemQty = order.ItemQty,
                    OrderDelivery = order.OrderDelivery,
                    OrderAddress = order.OrderAddress,
                    PhoneNumber = order.PhoneNumber
                })
                .ToList();
            return Ok(orders);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateOrder(CreateOrderModel newOrderModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!DateTime.TryParse(newOrderModel.OrderDelivery, out DateTime orderDelivery))
                    {
                        return BadRequest("Invalid date format");
                    }
                    Order newOrder = new Order()
                    {
                        ItemCode = newOrderModel.ItemCode,
                        ItemName = newOrderModel.ItemName,
                        ItemQty = newOrderModel.ItemQty,
                        OrderDelivery = orderDelivery,
                        OrderAddress = newOrderModel.OrderAddress,
                        PhoneNumber = newOrderModel.PhoneNumber
                    };
                    dbContext.Add(newOrder);
                    dbContext.SaveChanges();

                    return Created("New order created successfully", new OrderDTO()
                    {
                        Id = newOrder.Id,
                        ItemName = newOrder.ItemName
                    });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Create order error");
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateOrder(int id, EditOrderModel updateOrderModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order updateOrder = dbContext.Orders.Find(id);
                    if (updateOrder == null)
                    {
                        return NotFound("Order not found");
                    }
                    
                    if (!DateTime.TryParse(updateOrderModel.OrderDelivery, out DateTime updateOrderDelivery))
                    {
                        return BadRequest("Invalid date format");
                    }

                    updateOrder.OrderDelivery = updateOrderDelivery;
                    updateOrder.OrderAddress = updateOrderModel.OrderAddress;

                    dbContext.SaveChanges();

                    return Ok(new OrderDTO()
                    {
                        Id = updateOrder.Id,
                        ItemName = updateOrder.ItemName
                    });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Update order error");
        }
    }
}

