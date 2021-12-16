using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Livro
    {
        [Key]
        public int Id_livro {get; set;}

        [Required]
        public string Nome {get; set;}
        [Required]
        public string isbn {get; set;}
        [Required]
        public decimal Preco {get; set;}

        // Criação da FK autor
        [Required]
        public int AutorId_autor {get; set;}
        public Autor Autor {get; set;}
        
        // Criação da FK editora
        [Required]
        public int EditoraId_editora {get; set;}
        public Editora Editora {get; set;}

    }
}