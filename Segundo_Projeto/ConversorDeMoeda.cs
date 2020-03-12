///<summary>
///
/// Essa classe foi criada para realizar os calculos pertinentes a conversões do dolar
/// Ela inicializa a API, armazenas os dados em uma variável (dadosGerais) do tipo da 
/// minha classe (DadosAPI), que foi criada especificamente para o problema e realiza 
/// algumas outras funções (Mostrar a cotação do dolar e calcular o valor toral sem IOF)
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Conversao_Dolar
{
    class ConversorDeMoeda
    {
        public static DadosAPI dadosGerais = new DadosAPI();
        public static async void ChamadaAsync()
        {
            ///<summary>
            ///
            /// * Atenção * é muito importante que se utilize os métodos
            /// GetAwaiter() Pois ele espera que a API seja executada para
            /// somente depois executar o resto do programa e do método
            /// GetResult() pois ele retorna o resultado pego na consulta
            /// à API
            /// 
            /// </summary>

            dadosGerais = PegaDadosAPI.GetDados().GetAwaiter().GetResult();

        }

        public static void CotacaoDoDolar()
        {
            Console.WriteLine($"Cotação atual ({PegaDadosAPI.GetData()})");
            Console.WriteLine($"Valor de compra: {dadosGerais.valorCompra}");
            Console.WriteLine($"Valor de venda: {dadosGerais.valorVenda}");

        }


        public static double ValorTotal(double val_em_dols)
        {

            double total = val_em_dols * dadosGerais.valorCompra;
            return total;
        }

    }
}
