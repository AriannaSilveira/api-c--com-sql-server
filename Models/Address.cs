namespace petshop_management.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}

