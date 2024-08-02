using BackEnd.Extensions;
using BackEnd.Models;

namespace BackEnd.Dtos
{
    public class MembroDTO
    {
        public int usuario_id { get; set; }
        public string? usuario_nome { get; set; }
        public string? usuario_sobrenome { get; set; }
        public int Idade { get; set; }
        public string? FotoUrl { get; set; }
        public string? ConhecidoComo { get; set; }
        public DateTime Created { get; set; }
        public DateTime PrimeiroLogin { get; set; }
        public string? Genero { get; set; }
        public string? Introducao { get; set; }
        public string? Interesses { get; set; }
        public string? ProcurandoPor { get; set; }
        public string? Cidade { get; set; }
        public string?  Pais { get; set; }
        public List<FotoDTO>? Fotos { get; set; } 
    } 
}
