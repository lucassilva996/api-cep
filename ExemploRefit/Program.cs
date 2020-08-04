using Refit;
using RefitCepExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploRefit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu CEP");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informacoes do CEP: " + cepInformado);

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.Write($"\nLogradouro:{address.Logradouro}, \nBairro:{address.Bairro}, \nCidade:{address.Localidade}, \nUF:{address.Uf}, \nUnidade:{address.Unidade}, \nCódigo IBGE:{address.Ibge}, \nCódigo Gia:{address.Gia}");
                Console.ReadKey();

            } catch (Exception e)
            {
                Console.WriteLine("Erro na chamada da API" + e.Message);
            }
        }
    }
}
