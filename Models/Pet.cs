using System.ComponentModel.DataAnnotations.Schema;

namespace petshop_management.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        [Column("client_id")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

