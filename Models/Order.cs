namespace Back.Models
{
    public class Order
    {
        public enum OrderStatus
        {
            NotPayed = 0,
            Payed,
            Delivering,
            Delivered
        };

        public enum OrderPayment
        {
            None = 0,
            BankTransfer,
            CreditCard,
            Paypal
        };

        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public required float Total { get; set; }
        public OrderPayment Payment { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
