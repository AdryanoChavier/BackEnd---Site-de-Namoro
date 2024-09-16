using System.ComponentModel.DataAnnotations;

namespace BackEnd.Dtos
{
    public class RegistroDTO
    {

        [Required]
        public string usuario_nome {  get; set; } = string.Empty;
        [Required]
        public string usuario_sobrenome { get; set; } = string.Empty;
        [Required]
        [StringLength(8,MinimumLength = 4)]
        public string senha {  get; set; } = string.Empty;
    }
}
