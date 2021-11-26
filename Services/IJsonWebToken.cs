using Taqueria.Models;
using System.Security.Claims;

namespace Taqueria.Services
{
    public interface IJsonWebToken
    {
        string GenerarToken(Usuario usuario);
    }
}
