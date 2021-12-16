using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Autor
    {
        [Key]
        public int Id_autor {get; set;}

        [Required]
        public string Nome {get; set;}

        [Required]
        public string Sobrenome {get; set;}
    }
}