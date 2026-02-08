using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS_Fatto.Models
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [Display(Name = "Nome da Tarefa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O custo é obrigatório.")]
        [Range(0.00, double.MaxValue, ErrorMessage = "O custo deve ser maior ou igual a zero.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Custo (R$)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Custo { get; set; }

        [Required(ErrorMessage = "A data limite é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data-limite")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Required]
        public int Ordem { get; set; }
    }
}
