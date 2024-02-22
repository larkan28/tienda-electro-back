using static Back.Models.Order;

namespace Back.Models.DTO
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public required float Total { get; set; }
        public OrderPayment Payment { get; set; }
        public OrderStatus Status { get; set; }
        public required OrderProductDto[] Products { get; set; }
    }
}
