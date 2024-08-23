using System.ComponentModel.DataAnnotations;

namespace pra_test.Data
{
    public class Person
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Email { get; set; }
       
        public string PhoneNo { get; set; }
        public string Address { get; set; }
      
        public string State { get; set; }
       
        public string City { get; set; }
    }
}
