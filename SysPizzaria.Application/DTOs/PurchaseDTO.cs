namespace SysPizzaria.Application.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }
        
    }
}