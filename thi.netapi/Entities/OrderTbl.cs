using System.ComponentModel.DataAnnotations;

namespace thi.netapi.Entities
{
    public class OrderTbl
    {
        [Key]
        public int ItemCode { get; set; }
        public int ItemName { get; set; }
        public int ItemQty { get; set; }
        public string OrderDelivery { get; set; }
        public string OrderAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
