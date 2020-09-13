using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bludata.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public string CNPJ { get; set; }
        public  string UF { get; set; }
    }
}