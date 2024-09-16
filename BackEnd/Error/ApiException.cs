namespace BackEnd.Error
{
    public class ApiException(int statusCode, string mensagem, string? detalhes)
    {
        public int StatusCode {get;set;} = statusCode;
        public string Mensagem {get;set;} = mensagem;
        public string? Detalhes {get;set;} = detalhes;
    }
}
