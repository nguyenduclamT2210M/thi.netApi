using System.ComponentModel.DataAnnotations;

namespace thi.netapi.DTOs
{
    public class OrderDTO
    {
        
        public int ItemCode { get; set; }
        public int ItemName { get; set; }
        public int ItemQty { get; set; }
        public string OrderDelivery { get; set; }
        public string OrderAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
