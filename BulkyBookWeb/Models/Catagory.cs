using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Catagory
    {
        [Key] //Data Annotation for the primary key to identify by the entity framework
        public int Id { get; set; }
        [Required] // Data annotation for not null validation
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be between 1 and 100 only !!")]
        public string DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
