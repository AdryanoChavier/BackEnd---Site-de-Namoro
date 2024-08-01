using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BackEnd.Data
{
    public class Seed
    {
        public static async Task SeedUsuarios(DataContext context)
        {
            if (await context.Usuario.AnyAsync()) return;

            var usuarioData = await File.ReadAllTextAsync("Data/UsuarioSeedData.json");

            var options =  new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };

            var usuarios = JsonSerializer.Deserialize<List<AppUsuario>>(usuarioData,options);

            if(usuarios == null) return;

            foreach (var usuario in usuarios)
            {
                using var hmac = new HMACSHA512();

                usuario.usuario_nome = usuario.usuario_nome.ToLower();
                usuario.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                usuario.passwordSalt = hmac.Key;
                
                context.Usuario.Add(usuario);
            }

            await context.SaveChangesAsync();

        }
    }
}
