using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Editora
    {
        [Key]
        public int Id_editora {get; set;}

        [Required]
        public string Nome {get; set;}
    }
}