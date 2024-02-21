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
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo {0} precisa ter 11 caracteres")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "O campo {0} precisa ter 11 caracteres")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(9, MinimumLength = 9)]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Logadouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Localidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? UF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}


