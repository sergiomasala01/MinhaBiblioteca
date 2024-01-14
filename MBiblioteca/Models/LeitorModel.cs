using System.ComponentModel.DataAnnotations;

namespace MBiblioteca.Models
{
    public class LeitorModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"/^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}/", ErrorMessage = "O campo {0} está em formato invalido")]
        public int CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^\([1-9]{2}\)(?:[2-8]|9[0-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O campo {0} está em formato invalido")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}


