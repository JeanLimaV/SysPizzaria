namespace SysPizzaria.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodERP { get; set; }
        public decimal Price { get; set; }

        public ProductDTO() {}

        public ProductDTO(int id, string name, string codErp, decimal price)
        {
            Id = id;
            Name = name;
            CodERP = codErp;
            Price = price;
        }
    }
}