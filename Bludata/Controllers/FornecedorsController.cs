using System;
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
            var fornecedores = db.Fornecedores.Include(f => f.Empresa);
            return View(fornecedores.ToList());
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

        // POST: Fornecedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CNPJ,CPF,DataNascimento,Rg,Idade,DataHora,Telefone,EmpresaId")] Fornecedor fornecedor)
        {
            int idade = DateTime.Now.Year - fornecedor.DataNascimento.Year;
            fornecedor.Idade = idade;
            fornecedor.DataHora = DateTime.Now;
            if (fornecedor.CNPJ == null )
            {
                fornecedor.CNPJ = "";
            }
            if(fornecedor.CPF == null &&  fornecedor.Rg == null)
            {
                fornecedor.CPF = "";
                fornecedor.Rg = "" ;
                
            }
            //if (ModelState.IsValid)
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

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
