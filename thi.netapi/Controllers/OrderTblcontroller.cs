using Microsoft.AspNetCore.Mvc;
using thi.netapi.Context;
using thi.netapi.Models;
using thi.netapi.DTOs;
using thi.netapi.Entities;

namespace thi.netapi.Controllers
{
    [ApiController]
    [Route("api/order")]
    
    public class OrderTblcontroller : Controller
    {
        private readonly DBcontext _context;
        public OrderTblcontroller(DBcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<OrderDTO> dTOs = _context.OrderTbls
                .Select(m => new OrderDTO
                {
                   ItemCode = m.ItemCode,
                   ItemName = m.ItemName,
                   ItemQty = m.ItemQty,
                   OrderAddress = m.OrderAddress,
                   OrderDelivery    = m.OrderDelivery,
                   PhoneNumber = m.PhoneNumber,
                }).ToList();
            return Ok(dTOs);
        }
        [HttpPost]
        public IActionResult Create(OrderTblModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrderTbl order = new OrderTbl         
                    {
                        
                        ItemName = model.ItemName,
                        ItemQty = model.ItemQty,
                        OrderAddress = model.OrderAddress,
                        OrderDelivery = model.OrderDelivery,
                        PhoneNumber = model.PhoneNumber,
                    };
                    _context.OrderTbls.Add(order);
                    _context.SaveChanges();
                    return Created("", new OrderDTO
                    {
                        
                        ItemName = order.ItemName,
                        ItemQty = order.ItemQty,
                        OrderAddress = order.OrderAddress,
                        OrderDelivery = order.OrderDelivery,
                        PhoneNumber = order.PhoneNumber,
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok("Done");
        }
        [HttpPut]
        public IActionResult Edit(OrderTblModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.OrderTbls.Update(new OrderTbl
                    {
                        ItemName = model.ItemName,
                        ItemQty = model.ItemQty,
                        OrderAddress = model.OrderAddress,
                        OrderDelivery = model.OrderDelivery,
                        PhoneNumber = model.PhoneNumber,
                    });
                    _context.SaveChanges();
                    return Ok("Successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Error");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                OrderTbl sh = _context.OrderTbls.Find(id);
                _context.OrderTbls.Remove(sh);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
