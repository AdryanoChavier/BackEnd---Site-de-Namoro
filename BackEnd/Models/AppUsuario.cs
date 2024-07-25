using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class AppUsuario
    {

        [Key]
        public int usuario_id { get; set; }
        public required string usuario_nome { get; set; }
        public string usuario_sobrenome { get; set; }
        public required byte[] passwordHash { get; set; }
        public required byte[] passwordSalt { get; set; }
    }
}
