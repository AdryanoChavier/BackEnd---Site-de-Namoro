using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("Fotos")]
    public class Foto
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId {  get; set; }
        
        
        // Relação de 1 pra muitos

        public int AppUsuarioId { get; set; }
        public AppUsuario AppUsuario { get; set; } = null;


    }
}
