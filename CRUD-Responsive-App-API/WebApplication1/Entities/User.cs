using System.ComponentModel.DataAnnotations;

namespace CRUD_Reponsive_Web_API.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }
     
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
      
        public string DateOfBirth { get; set; }

        public virtual Document Document { get; set; }

    }
}
