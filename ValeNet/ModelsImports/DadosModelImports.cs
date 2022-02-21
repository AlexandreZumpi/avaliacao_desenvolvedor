using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValeNet.ModelsImports
{
    [IgnoreEmptyLines(true), DelimitedRecord("\t"), IgnoreFirst(1)]
    public class DadosModelImports
    {
        public string Comprador { get; set; }
        public string Descricao { get; set; }

        [FieldConverter(typeof(MoneyConverter))]
        public decimal PrecoUnitario { get; set; }

       // [FieldConverter(typeof(MoneyConverter))]
        public int Quantidade { get; set; }
        public string Endereco { get; set; }
        public string Fornecedor { get; set; }
    }


    public class MoneyConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            var splits = from.Split('.');
            if (splits.Length > 1)
            {
                if (splits[1].Length < 2)
                {
                    from = from + '0';
                }
            }

            return Convert.ToDecimal(Decimal.Parse(from) / 100);
        }

        public override string FieldToString(object fieldValue)
        {
            return ((decimal)fieldValue).ToString("#.##").Replace(".", "");
        }

    }

}
