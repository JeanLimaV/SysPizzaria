namespace SysPizzaria.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
