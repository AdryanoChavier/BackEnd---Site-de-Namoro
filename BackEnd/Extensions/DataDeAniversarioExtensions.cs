namespace BackEnd.Extensions
{
    public static class DataDeAniversarioExtensions
    {
        public static int CalularIdade(this DateOnly dob)
        {
            var hoje = DateOnly.FromDateTime(DateTime.Now);

            var idade = hoje.Year - dob.Year;

            if (dob > hoje.AddYears(-idade)) idade--;

            return idade;
        }
    }
}
