using System.ComponentModel.DataAnnotations.Schema;

namespace petshop_management.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Column("address_id")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Pet> Pets { get; set; }

        
    }
}


//     private List<Client> _clientList { get; set; }

//     public void CreateClient(){
//             try
//             {
//                  _clientList = new List<Client>()
//             {
//                 new Client(){ Id = 1, AddressId = 1, Name= "Paulo",Email="paulo@email.com", Phone = "83981045351"},
//                 new Client(){ Id = 2, AddressId = 1,Name= "Alexandre",Email="alex@email.com", Phone = "83981045351"},
//                 new Client(){ Id = 3, AddressId = 1,Name= "Carlos",Email="carlos@email.com", Phone = "83981045351"},
//                 new Client(){ Id = 4, AddressId = 1,Name= "Bianca",Email="bia@email.com", Phone = "83981045351"},
//                 new Client(){ Id = 5, AddressId = 1,Name= "Laura",Email="laura@email.com", Phone = "83981045351"}
//             };
//             }
//             catch (System.Exception ex)
//             {
                
//                 throw new Exception(ex.Message);
//             }
//         }

//         public List<Client> SearchClient()
//         {
//             try
//             {
//                 return _clientList;
//             }
//             catch (System.Exception ex)
//             {
                
//                 throw new Exception(ex.Message);
//             }
//         }
// }