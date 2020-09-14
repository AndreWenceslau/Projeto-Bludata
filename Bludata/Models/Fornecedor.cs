using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bludata.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)", ErrorMessage = "Informe um CNPJ ou CPF válido...")]
        public string CNPJ { get; set; }
        public DateTime DataHora { get; set; }
        [Required]
        public string Telefone { get; set; }
       
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

    }
}