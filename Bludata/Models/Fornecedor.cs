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
       // [StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }

        //[Required]
        //[RegularExpression(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)", ErrorMessage = "Informe um CNPJ válido...")]
        public string CNPJ { get; set; }

        //[Required]
        //[RegularExpression(@"(/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/)", ErrorMessage ="Informe um CPF válido")]
        public string CPF { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        //[Required]
        public string Rg { get; set; }

        public int Idade { get; set; }

        public DateTime DataHora { get; set; }

        [Required]
        public string Telefone { get; set; }
       
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

    }
}