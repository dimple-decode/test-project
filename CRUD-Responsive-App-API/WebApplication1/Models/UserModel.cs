using CRUD_Reponsive_Web_API.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Reponsive_Web_API.Models
{
    public class UserModel
    {
     
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string  DateOfBirth { get; set; }

        [Required]
        public DocumentModel Document { get; set; } 

        [Required]
        public string FileName { get; set; }
    }

   
}
