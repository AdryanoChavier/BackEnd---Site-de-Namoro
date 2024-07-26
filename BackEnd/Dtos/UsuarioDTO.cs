namespace BackEnd.Dtos
{
    public class UsuarioDTO
    {
        public required string usuario_nome {  get; set; }
        public required string usuario_sobrenome { get; set; }
        public required string token {  get; set; }
    }
}
