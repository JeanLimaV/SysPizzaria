namespace SysPizzaria.Domain.Entities
{
    public class Purchase : EntityBase
    {
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
