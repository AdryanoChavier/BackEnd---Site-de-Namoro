using BackEnd.Extensions;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class AppUsuario
    {

        [Key]
        public int usuario_id { get; set; }
        public required string usuario_nome { get; set; }
        public string usuario_sobrenome { get; set; }
        public byte[] passwordHash { get; set; } = [];
        public byte[] passwordSalt { get; set; } = [];
        public DateOnly DataDeNascimento { get; set; }
        public required string ConhecidoComo { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime PrimeiroLogin { get; set; } = DateTime.UtcNow;
        public required string Genero { get; set; }
        public string? Introducao {  get; set; }
        public string? Interesses {  get; set; }
        public string? ProcurandoPor {  get; set; }
        public required string Cidade {  get; set; }
        public required string Pais {  get; set; }
        public List<Foto> Fotos { get; set; } = [];

        //public int GetIdade()
        //{
        //    return DataDeNascimento.CalularIdade();
        //}

    }
}
