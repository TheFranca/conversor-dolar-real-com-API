///<summary>
///
/// Classe criada aos moldes das keys do JSON
///
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Conversao_Dolar
{
    public class DadosAPI
    {
        [JsonProperty(PropertyName = "cotacaoCompra")]
        public double valorCompra { get; set; }

        [JsonProperty(PropertyName = "cotacaoVenda")]
        public double valorVenda { get; set; }
    }

    public class Value
    {
        public List<Array> value;

        public static implicit operator Value(DadosAPI v)
        {
            throw new NotImplementedException();
        }
    }


}
