using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Reponsive_Web_API.Entities
{
    public class Document
    {
      
        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public float DocumentSize { get; set; }
        public string DocumentData { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}
