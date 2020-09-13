using Bludata.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bludata.Acessodados
{
    public class EmpresasInit : CreateDatabaseIfNotExists<FornecedorContext>
    {
        protected override void Seed(FornecedorContext context)
        {
            List<Empresa> empresas = new List<Empresa>()
            {
              new Empresa() {
              Nome = "Empresa 01",
              UF = "Santa Catarina",
              CNPJ = "15.713.440/0001-63"
              },

              new Empresa() {
              Nome = "Empresa 02",
              UF = "São Paulo",
              CNPJ = "15.713.440/0001-64"
              },

              new Empresa() {
              Nome = "Empresa 03",
              UF = "Paraná",
              CNPJ = "15.713.440/0001-65"
              },

            };
            empresas.ForEach(x => context.Empresas.Add(x));


            List<Fornecedor> fornecedores = new List<Fornecedor>()
            {
                new Fornecedor()
                {
                    Nome = "Fornecedor 01",
                    CNPJ = "131.264.240-82",
                    DataHora = DateTime.Now,
                    Telefone = "(47) 3334-2468",
                    Empresa =  empresas.FirstOrDefault(x => x.Nome == "Empresa 01")
                    
                },

                new Fornecedor()
                {
                    Nome = "Fornecedor 02",
                    CNPJ = "131.264.240-83",
                    DataHora = DateTime.Now,
                    Telefone = "(47) 3334-2469",
                    Empresa =  empresas.FirstOrDefault(x => x.Nome == "Empresa 02")
                },

                new Fornecedor()
                {
                    Nome = "Fornecedor 03",
                    CNPJ = "131.264.240-84",
                    DataHora = DateTime.Now,
                    Telefone = "(47) 3334-2470",
                    Empresa =  empresas.FirstOrDefault(x => x.Nome == "Empresa 03")
                },

               

            };
            fornecedores.ForEach(y => context.Fornecedores.Add(y));
            context.SaveChanges();

        }
    }
}