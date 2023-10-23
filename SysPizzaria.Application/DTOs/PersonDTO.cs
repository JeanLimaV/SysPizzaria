namespace SysPizzaria.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }

        public PersonDTO() {}

        public PersonDTO(int id, string name, string document, string phone)
        {
            Id = id;
            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}