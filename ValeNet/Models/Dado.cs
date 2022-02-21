using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ValeNet.Models
{
    public class Dado : BaseModel
    {
        public string Comprador { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public string Endereco { get; set; }
        public string Fornecedor { get; set; }
        public string NomeArquivo { get; set; }
        public string Guid { get; set; }
        public DateTime Criacao { get; set; }

        [NotMapped]
        public Decimal TotalDado { get { return PrecoUnitario * Quantidade; } }
    }
}
