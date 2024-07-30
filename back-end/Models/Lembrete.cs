using System.ComponentModel.DataAnnotations;
using SistemaDeLembretes.Validations;

namespace SistemaDeLembretes.Models
{
    public class Lembrete {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data invalida"), Required(ErrorMessage = "O Campo Data é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DateNotInPast]
        public DateTime Data { get; set; }

    }
}