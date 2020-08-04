using ExemploRefit;
using Refit;
using System.Threading.Tasks;

namespace RefitCepExample
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}