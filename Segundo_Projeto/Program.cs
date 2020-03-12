///<summary>
///
/// Para que esse programa funcione recomenda-se que seja efetuado a instalação do pacote
/// Newtonsoft.Json através do Gerenciador de Pacotes NuGet (caso esteja utilizando Visual Studio).
/// A utilização desse pacote facilita o manuseio de arquivos JSON
/// 
/// </summary>

using System;

namespace Projeto_Conversao_Dolar
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversorDeMoeda.ChamadaAsync();

            ConversorDeMoeda.CotacaoDoDolar();
                                 
            Console.Write($"Quando dólares deseja comprar? ");
            double valor_em_dols = Double.Parse(Console.ReadLine());

            double val_total = ConversorDeMoeda.ValorTotal(valor_em_dols);

            double val_liquido = val_total + (val_total * 6.0 / 100);

            Console.WriteLine($"Valor a ser pago em reais (Bruto): R${ConversorDeMoeda.ValorTotal(valor_em_dols):F2}"); 
            Console.WriteLine($"Valor a ser pago em reais com IOF de 6%: R${val_liquido:F2}"); 

        }
    }
}
