using MBiblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace MBiblioteca.Models
{
    public class EmprestimoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Livro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Leitor { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Data de Emprestimo")]
        public DateTime DataEmprestimo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Data de Devolucao")]
        public DateTime DataDevolucao { get; set; }
    }
}