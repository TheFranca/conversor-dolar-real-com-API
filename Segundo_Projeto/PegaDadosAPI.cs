/// <summary>
/// 
/// Esta classe é responsavel por fazer acesso a API do Banco central e pegar a cotação
/// do dia anterior.
/// 
/// É composta por dois metodos: GetDados() e GetData()
/// 
/// O método Getdada() é responsável por pegara data atual, subtrair um dia e retornar a
/// data do dia anterior
/// 
/// O método GetDados() é responsável por acessar e pegar os dados da API do banco central
/// *mais informações no escopo do método*
/// 
/// 
/// *ATENÇÃO* Existem 3 casos de consumação de JSON
/// 1) Consumação direta, em que não existe dados complexos (Dados dentro de Array)
/// 2) Consumação por niveis: Que você tem que acessar os dados que estão dentro de Arrays/Listas
///     --É o caso do atual programa
/// 3) Consumação por niveis complexos: Acesso de dados que estão dentro de Arrays que estão dentro de outros Arrays
/// 
/// </summary> 

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Conversao_Dolar
{
    class PegaDadosAPI
    {
        //Necessário para iniciar a comunicação
        public static HttpClient client = new HttpClient();

        public static async Task<DadosAPI> GetDados()
        {
            //Como o json que se pega possui arrays, é necessario criar uma classe
            //para que se possa pegar os dados corretamente
            DadosAPI dados = new DadosAPI();

            //Pega a data do dia anterior para poder ser passada no caminho da API
            string data = GetData();

            //As próximas duas linhas são responsáveis por acessar e pegar os dados na API
            client.BaseAddress = new Uri("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/");
            HttpResponseMessage resposta = await client.GetAsync($"CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao=%27{data}%27&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda");

            //Armazena a resposta da API em uma string
            string texto_do_json = await resposta.Content.ReadAsStringAsync();

            //Converte os dados do Json para poder facilitar o manuseamentos dos dados
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(texto_do_json);

            //Acessa os dados em de cada posição do json
            //OBS: Caso existissem mais que dois dados, bastaria fazer um
            //foreach percorrendo o json e armazenando os dados em um Array ou List
            dados.valorCompra = obj.value[0].cotacaoCompra;
            dados.valorVenda = obj.value[0].cotacaoVenda;
           
            //Retornar os dados do tipo da minha classe "DadosAPI"
            return dados;
        }

        public static string GetData()
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();

            int dia_anterior = Int32.Parse(dia);
            dia_anterior -= 1;

            string data = mes + "-" + dia_anterior.ToString() + "-" + ano;

            return data;

        }
    }
}
