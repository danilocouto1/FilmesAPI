using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Genero Obrigatorio")]
        public string Genero { get; set; }

        public override string ToString()
        {
            return $"N# {Codigo} : {Nome} - Categora: {Genero}";
        }

    }
}
