namespace SysPizzaria.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = null!;
        public string CodERP { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
