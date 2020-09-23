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
              CNPJ = "15.713.440/0001-63",
              UF = "SC"
              },

              new Empresa() {
              Nome = "Empresa 02",
              CNPJ = "15.713.440/0001-64",
              UF = "SP"
              },

              new Empresa() {
              Nome = "Empresa 03",
              CNPJ = "15.713.440/0001-65",
              UF = "PR"
              },

            };
            empresas.ForEach(e => context.Empresas.Add(e));


            List<Fornecedor> fornecedores = new List<Fornecedor>()
            {
                new Fornecedor()
                {
                    Nome = "Fornecedor 01",
                    CNPJ = "15.713.440/0001-90",
                    CPF = "",
                    DataNascimento = DateTime.Now,
                    Rg = "",
                    Idade = 0,
                    DataHora = DateTime.Now,
                    Telefone = "(47) 3334-2468",
                    Empresa =  empresas.FirstOrDefault(x => x.Nome == "Empresa 01")

                },
                new Fornecedor()
                {
                    Nome = "Fornecedor 02",
                    CNPJ = "15.713.440/0001-91",
                    CPF = "",
                    DataNascimento = DateTime.Now,
                    Rg = "",
                    Idade = 0,
                    DataHora = DateTime.Now,
                    Telefone = "(47) 3334-2469",
                    Empresa =  empresas.FirstOrDefault(x => x.Nome == "Empresa 02")
                },

                new Fornecedor()
                {
                    Nome = "Fornecedor 03",
                    CNPJ = "",
                    CPF = "048.322.529-09",
                    DataNascimento = DateTime.Now.AddYears(18),
                    Rg = "5.936.145",
                    Idade = 18,
                    DataHora = DateTime.Now,
                    Telefone = "(47) 3334-2470",
                    Empresa =  empresas.FirstOrDefault(x => x.Nome == "Empresa 03")
                }
            };
            fornecedores.ForEach(f => context.Fornecedores.Add(f));
            context.SaveChanges();

        }
    }
}