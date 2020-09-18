﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bludata.Acessodados;
using Bludata.Models;

namespace Bludata.Controllers
{
    public class FornecedorsController : Controller
    {
        private FornecedorContext db = new FornecedorContext();

        // GET: Fornecedors
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listar(Fornecedor fornecedor, int pagina = 1, int registros = 5)
        {
            var fornecedores = db.Fornecedores.Include(f => f.Empresa);
            if (!String.IsNullOrWhiteSpace(fornecedor.Nome))
            {
                fornecedores = fornecedores.Where(x => x.Nome.Contains(fornecedor.Nome));
            }
            if (!String.IsNullOrWhiteSpace(fornecedor.CPF))
            {
                fornecedores = fornecedores.Where(x => x.CPF.Contains(fornecedor.CPF));
            }
            if (!String.IsNullOrWhiteSpace(fornecedor.CNPJ))
            {
                fornecedores = fornecedores.Where(x => x.CNPJ.Contains(fornecedor.CNPJ));
            }
            if(DateTime.MinValue.Date != fornecedor.DataHora )
            {
                fornecedores = fornecedores.Where(x => x.DataHora.Equals(fornecedor.DataHora));
            }
            var fornecedoresPaginado = fornecedores.OrderBy(x => x.Nome).Skip((pagina - 1) * registros).Take((registros));
            return PartialView("_Listar", fornecedoresPaginado.ToList());
        }

        // GET: Fornecedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }


        // GET: Fornecedors/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CNPJ,CPF,DataNascimento,Rg,Idade,DataHora,Telefone,EmpresaId")] Fornecedor fornecedor)
        {
            int idade = DateTime.Now.Year - fornecedor.DataNascimento.Year;
            fornecedor.Idade = idade;
            fornecedor.DataHora = DateTime.Now;
            var empresa = db.Empresas.FirstOrDefault(x => x.Id == fornecedor.EmpresaId);
            if (fornecedor.CNPJ == null)
            {
                fornecedor.CNPJ = "";
            }
            if (fornecedor.CPF == null && fornecedor.Rg == null)
            {

            }

            if (fornecedor.Idade < 18 && empresa.UF == "PR")
            {
                TempData["mensagemErro"] = "Não é possível realizar o cadastro. Pois a pessoa cadastrada é menor de idade";
                ViewBag.EmpresaId = new SelectList(db.Empresas, "Id", "Nome", fornecedor.EmpresaId);
                return View(fornecedor);
            }
            // if (ModelState.IsValid)
            //{

            db.Fornecedores.Add(fornecedor);
            db.SaveChanges();
            return RedirectToAction("Index");
            //}

            //ViewBag.EmpresaId = new SelectList(db.Empresas, "Id", "Nome", fornecedor.EmpresaId);
            //return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "Id", "Nome", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CNPJ,DataHora,Telefone,EmpresaId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "Id", "Nome", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            db.Fornecedores.Remove(fornecedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
