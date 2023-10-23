namespace SysPizzaria.Application.DTOs
{
    public class PurchaseDTO
    {
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }

        public PurchaseDTO() {}

        public PurchaseDTO(int productId, int personId, DateTime date)
        {
            ProductId = productId;
            PersonId = personId;
            Date = date;
        }
    }
}