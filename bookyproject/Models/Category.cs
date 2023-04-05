using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookyproject.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [DisplayName("Display Of Order")]
        [Range(10,20,ErrorMessage ="the prive must be at least 10 and at the most 20")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
            








   
    }
}
