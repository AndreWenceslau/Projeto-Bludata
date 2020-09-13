using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bludata.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataHora { get; set; }
        public string Telefone { get; set; }

        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

    }
}